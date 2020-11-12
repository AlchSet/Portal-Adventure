using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLife : StateMachineBehaviour
{

    Damageable d;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        d = animator.GetComponentInChildren<Damageable>();

        animator.SetFloat("Life", d.life);

    }




}
