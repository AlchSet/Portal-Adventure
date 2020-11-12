using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedIdle : StateMachineBehaviour
{
    public float duration;
    float elapsed;
    EnemyAI ai;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai = animator.GetComponent<EnemyAI>();
        ai.stopMove = true;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        elapsed += Time.deltaTime;

        if(elapsed>=duration)
        {
            animator.SetTrigger("Continue");
            elapsed = 0;
        }
        
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai.stopMove = false;
    }
}
