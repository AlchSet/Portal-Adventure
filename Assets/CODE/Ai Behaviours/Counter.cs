using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : StateMachineBehaviour
{

    public string VarName;
    public int Count = 0;

    public bool resetCounter;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if(resetCounter)
        {
            Count = 0;
            animator.SetInteger(VarName, Count);
        }
        else
        {
            Count = animator.GetInteger(VarName);
            Count++;
            animator.SetInteger(VarName, Count);
        }
       
    }



}
