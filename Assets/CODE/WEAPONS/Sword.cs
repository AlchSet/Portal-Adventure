using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponBase
{
    public Hurtbox hurtbox;


    public ParticleSystem particles;

    ParticleSystem.EmissionModule em;

    AudioSource sfx;


    // Update is called once per frame
    void Update()
    {

    }


    private void Awake()
    {
        hurtbox.rootWPN = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();

        controller = transform.root.GetComponent<Controller2D>();

        em = particles.emission;

        em.enabled = false;

        sfx = GetComponent<AudioSource>();
    }

    public override void Dispose()
    {
        //throw new System.NotImplementedException();
    }

    public override bool GetInUse()
    {
        throw new System.NotImplementedException();
    }

    public override void OnButtonDown()
    {
        //Debug.Log("USE WeaPON");

        sfx.PlayOneShot(sfx.clip);

        switch(controller.faceDir)
        {
            case Controller2D.Direction.North:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;

            case Controller2D.Direction.South:
                transform.eulerAngles = new Vector3(0, 0, 180);
                break;


            case Controller2D.Direction.West:

                transform.eulerAngles = new Vector3(0, 0, 90);
                break;


            case Controller2D.Direction.East:
                transform.eulerAngles = new Vector3(0, 0, -90);
                break;
        }




        anim.Play("Sword Slash", -1, 0f);
    }

    public override void OnButtonUp()
    {
        //throw new System.NotImplementedException();
    }



    public override void EnableAttacking()
    {
        base.EnableAttacking();
        em.enabled = true;
        hurtbox.isActive = true;
        OnAttack.Invoke();
    }


    public override void DisableAttacking()
    {
        base.DisableAttacking();
        em.enabled = false;
        hurtbox.isActive = false;
        OnExitAttack.Invoke();
    }
    // Start is called before the first frame update

}
