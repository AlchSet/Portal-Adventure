using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : StateMachineBehaviour
{

    EnemyAI ai;

    public string animName;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai = animator.GetComponent<EnemyAI>();


        ai.anim.Play(animName);

    }
}
