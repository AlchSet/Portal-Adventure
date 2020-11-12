using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetFromList : StateMachineBehaviour
{
    EnemyAI ai;

    public int targetIndex;
    TargetList target;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai = animator.GetComponent<EnemyAI>();
        target = animator.GetComponent<TargetList>();
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai.SetDestination(target.list[targetIndex].position);
    }

}
