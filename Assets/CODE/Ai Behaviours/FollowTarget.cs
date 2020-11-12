using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : StateMachineBehaviour
{
    EnemyAI ai;
    Transform p;

    public bool Attack;

    public float attackDistance=1;

    Controller2D controller;

    public float speed;

    bool trigged;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai = animator.GetComponent<EnemyAI>();
        p = GameObject.FindGameObjectWithTag("Player").transform;
        controller = animator.GetComponent<Controller2D>();

        controller.speed = speed;

        ai.anim.Play("Walk");

        trigged = false;

        ai.SetDestination(p.position);
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai.SetDestination(p.position);

        if(Attack&&!trigged)
        {
            if (Vector2.Distance(animator.transform.position, p.position) < attackDistance)
            {
                Debug.Log("ATTACK PLAYER");
                animator.SetTrigger("Continue");
                trigged = true;
            }
        }
        

    }
}
