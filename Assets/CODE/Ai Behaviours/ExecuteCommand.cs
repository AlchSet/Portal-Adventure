using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteCommand : StateMachineBehaviour
{
    public int command;

    EnemyCommands commands;



    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        commands = animator.GetComponent<EnemyCommands>();

        commands.Commands[command].Invoke();

    }


}
