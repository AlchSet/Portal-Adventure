using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : StateMachineBehaviour
{
    EnemyAI ai;

    public float distance = 2;

    public bool loop = true;

    Animator anim;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai = animator.GetComponent<EnemyAI>();

        anim = animator;

        if(loop)
        {
            ai.OnFinishPath += NextPoint;
        }
        else
        {
            ai.OnFinishPath += Continue;
        }
        

        
        Vector2 p = Random.insideUnitCircle.normalized;
        p = p * distance;
        p = (Vector2)animator.transform.position + p;


        NNInfo info = AstarPath.active.GetNearest(p);

        Vector3 closest = info.position;

       

        ai.SetDestination(closest);
        ai.stopMove = false;
    }


    public void NextPoint()
    {
        Vector2 p = Random.insideUnitCircle.normalized;
        p = p * distance;
        p = (Vector2)ai.transform.position + p;


        NNInfo info = AstarPath.active.GetNearest(p);

        Vector3 closest = info.position;



        ai.SetDestination(closest);

    }


    public void Continue()
    {
        anim.SetTrigger("Continue");
        ai.stopMove = true;
        //ai.controller.move = false;
    }



}
