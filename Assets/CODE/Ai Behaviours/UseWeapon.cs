using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : StateMachineBehaviour
{


    float elapsed = 2;

    WeaponList weapons;


    public int weaponIndex;


    Transform player;

    Controller2D controller;

    EnemyAI ai;



    public bool stopMove;

    bool subbed;

    bool attacked;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        weapons = animator.GetComponent<WeaponList>();

        controller = animator.GetComponent<Controller2D>();


        player = GameObject.FindGameObjectWithTag("Player").transform;

        ai = animator.GetComponent<EnemyAI>();


        if (stopMove)
        {
            if (!subbed)
            {
                weapons.weaponList[weaponIndex].OnAttack += StopMove;
                weapons.weaponList[weaponIndex].OnExitAttack += ResumeMove;
                subbed = true;
            }

        }
        attacked = false;
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {


        //Vector2 dir = player.position - animator.transform.position;

        //controller.SetInputVel(dir.normalized);

        //ai.anim.SetFloat("X", controller.InputVel.x);
        //ai.anim.SetFloat("Y", controller.InputVel.y);


        elapsed += Time.deltaTime;
        if (!attacked)
        {
            weapons.weaponList[weaponIndex].OnButtonDown();
            attacked = true;
        }




        //if(elapsed>=2)
        //{
        //    elapsed = 0;

        //    weapons.weaponList[weaponIndex].OnButtonDown();






        //    Debug.Log("FIrE");
        //}

    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //elapsed = 0;

        attacked = false;
    }

    public void StopMove()
    {
        controller.move = false;
        controller.enabled = false;
        if (ai.anim)
            ai.anim.Play("UseWeapon");

    }


    public void ResumeMove()
    {
        controller.move = true;
        controller.enabled = true;
        //ai.anim.Play("Walk");
    }


}
