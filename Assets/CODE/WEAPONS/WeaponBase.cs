using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour {

    public bool Equipped;

    public bool inAttack;

    public float maxAmmo;
    public float currentAmmo;

    public float knockbackforce = 5;

    public delegate void AttackEvent();
    public AttackEvent OnAttack;
    public AttackEvent OnExitAttack;

    public AttackEvent OnAddAmmo;


    public Animator anim;

    public Controller2D controller;

    public abstract void OnButtonDown();
    public abstract void OnButtonUp();
    public abstract bool GetInUse();
    public abstract void Dispose();



    public virtual void EnableAttacking()
    {

    }

    public virtual void DisableAttacking()
    {

    }


    public void AddAmmo(float i)
    {
        currentAmmo += i;
        if(OnAddAmmo!=null)
        {
            OnAddAmmo.Invoke();
        }
    }
}
