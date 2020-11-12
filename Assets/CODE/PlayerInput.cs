using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Controller2D))]
public class PlayerInput : MonoBehaviour
{

    public enum PlayerState { Normal, Attacking, Stunned }

    public PlayerState state = PlayerState.Normal;


    Controller2D controller;

    bool changearea;

    public bool freeze;

    float camSpeed = 10000;//30;

    public Animator anim;


    public WeaponBase sword;

    public WeaponBase bow;

    public WeaponBase bomb;


    public Damageable damageable;

    public PlayerState lastState;


    public StatusEffect Status;



    public Area lastArea;

    Area currentArea;



    public delegate void AddAction(int c);

    public AddAction OnCollectCoin;

    public int Coins;


    public AudioClip coinSFX;
    public AudioClip healthSFX;


    AudioSource sfx;

    Teleporter tele;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<Controller2D>();
        sfx = GetComponent<AudioSource>();
        if (sword)
        {
            sword.OnAttack += AttackFreeze;
            sword.OnExitAttack += ExitAttackFreeze;
        }

        OnCollectCoin += AddCoins;

    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze)
            controller.SetInputVel(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        //else
        //    controller.SetInputVel(Vector2.zero);


        anim.SetFloat("X", controller.FacingDirection.x);
        anim.SetFloat("Y", controller.FacingDirection.y);



        switch (state)
        {
            case PlayerState.Normal:
                if (controller.isMoving)
                {
                    anim.Play("Walk");
                }
                else
                {
                    anim.Play("Idle");
                }


                //if (Input.GetMouseButtonDown(0))
                //{
                //    Debug.Log("ATK");
                //}
                if (Input.GetKeyDown(KeyCode.X) && !bow.inAttack)
                {

                    sword.OnButtonDown();
                }
                if (Input.GetKeyUp(KeyCode.X))
                {

                    sword.OnButtonUp();
                }



                if (Input.GetKeyDown(KeyCode.Z) && !sword.inAttack)
                {

                    bow.OnButtonDown();
                }
                if (Input.GetKeyUp(KeyCode.Z))
                {

                    bow.OnButtonUp();
                }

                if (Input.GetKeyDown(KeyCode.C) && !sword.inAttack)
                {

                    bomb.OnButtonDown();
                }
                if (Input.GetKeyUp(KeyCode.C))
                {

                    bomb.OnButtonUp();
                }


                if (Input.GetKeyDown(KeyCode.E))
                {

                    RaycastHit2D hit = Physics2D.Raycast(transform.position, controller.FacingDirection, 1, 1 << LayerMask.NameToLayer("NPC"));

                    if (hit.collider)
                    {
                        Debug.Log("TALK TO " + hit.collider.name);

                        hit.collider.GetComponent<Npc>().Talk(TalktoNPC, ExitTalkToNPC);

                    }

                }



                break;


            case PlayerState.Attacking:
                break;


            case PlayerState.Stunned:



                break;
        }




    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Area")
        {
            Debug.Log("CHANGE AREA");
            //if(lastArea!=null)
            //{
            //    lastArea.DisableEnemies();
            //}
            currentArea = collision.GetComponent<Area>();

            //currentArea.EnableEnemies();

            //lastArea = currentArea;
            if (!changearea)
            {
                StartCoroutine(ChangeArea(collision.transform.position));
            }
        }


        if (collision.tag == "Teleport")
        {
            Debug.Log("TELE INDORS");

            tele = collision.gameObject.GetComponent<Teleporter>();
            StartCoroutine(TeleportPlayer());

        }

        //if (damageable)
        //{
        //    if (collision.tag == "Enemy")
        //    {
        //        Damageable.CollisionInfo i = new Damageable.CollisionInfo();
        //        i.position = collision.transform.position;
        //        i.totalDmg = 1;


        //        damageable.DealDamage(i);
        //        //PlayHitStun();
        //        Debug.Log("OUCH");
        //    }

        //    if (collision.tag == "Health1")
        //    {
        //        damageable.HealAdditive(3);

        //        Destroy(collision.gameObject);

        //    }




        //}

        //if (collision.tag == "Fire")
        //{
        //    Debug.Log("BURN");

        //    Status.StartBurning();

        //}


        //--------------------------------
        if (collision.tag == "Gold")
        {
            Debug.Log("COIN");
            if (OnCollectCoin != null)
            {
                OnCollectCoin(100);
            }

            Destroy(collision.gameObject);

            //Debug.Log("BURN");

            //Status.StartBurning();

        }
        //if (collision.tag == "HealthUp")
        //{
        //    damageable.UpgradeHealth(2);
        //    sfx.PlayOneShot(healthSFX);
        //    Destroy(collision.gameObject);

        //}
        if (collision.tag == "Heal")
        {
            damageable.HealAdditive(12);
            sfx.PlayOneShot(healthSFX);
            Destroy(collision.gameObject);

        }
        if (collision.tag == "ArrowCollect")
        {
            //damageable.HealAdditive(1);

            bow.AddAmmo(3);
            sfx.PlayOneShot(healthSFX);
            Destroy(collision.gameObject);

        }if (collision.tag == "BombCollect")
        {
            //damageable.HealAdditive(1);

            bomb.AddAmmo(3);
            sfx.PlayOneShot(healthSFX);
            Destroy(collision.gameObject);

        }

        //-------------------------------------


        //if(collision.gameObject.layer==LayerMask.NameToLayer("Collectable"))
        //{
        //    Debug.Log("Collect");
        //    collision.GetComponent<Collectable>().OnCollect.Invoke();
        //}



        if (collision.tag == "Projectile")
        {
            collision.GetComponent<Projectile>().CleanUp.Invoke();

            Damageable.CollisionInfo i = new Damageable.CollisionInfo();
            i.position = -collision.transform.position;
            i.totalDmg = 1;

            bow.Dispose();
            damageable.DealDamage(i);
        }

        //collision.
        //Debug.Log(collision.name);
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (damageable)
        {
            if (collision.tag == "Enemy")
            {



                //RaycastHit2D hit = Physics2D.Linecast(transform.position, collision.transform.position);



                Damageable.CollisionInfo i = new Damageable.CollisionInfo();

                i.knockbackForce = 5;

                i.position = collision.transform.parent.position;
                i.totalDmg = 1;


                damageable.DealDamage(i);

                //damageable.DealDamage(1);

                //PlayHitStun();
                Debug.Log("OUCH");
            }

            if (collision.tag == "Health1")
            {
                damageable.HealAdditive(3);

                Destroy(collision.gameObject);

            }




        }

        if (collision.tag == "Fire")
        {
            Debug.Log("BURN");

            Status.StartBurning();

        }
    }

    public void AttackFreeze()
    {
        anim.Play("Attack");
        state = PlayerState.Attacking;
        controller.freeze = true;
        controller.lockDirection = true;
    }

    public void ExitAttackFreeze()
    {
        state = PlayerState.Normal;
        controller.freeze = false;
        controller.lockDirection = false;
    }



    public void OnStun()
    {
        sword.Dispose();
        Debug.Log("STUN");
        lastState = state;
        state = PlayerState.Stunned;
        controller.enabled = false;
    }

    public void ExitStun()
    {
        Debug.Log("EXIT  STUN");
        controller.enabled = true;
        if (lastState == PlayerState.Attacking)
        {
            state = PlayerState.Normal;
        }
        else
        {
            state = lastState;
        }
    }


    //public void PlayHitStun()
    //{

    //    StartCoroutine(HitStun());

    //    //if(!dmg.isHitStun)
    //    //{

    //    //}
    //}

    public void AddCoins(int coin)
    {
        Coins += coin;
        sfx.PlayOneShot(coinSFX);
    }


    public void SubtractCoins(int coin)
    {
        Coins -= coin;
        sfx.PlayOneShot(coinSFX);
    }

    //Not used
    IEnumerator HitStun()
    {
        controller.enabled = false;
        PlayerState lastState = state;
        state = PlayerState.Stunned;


        Debug.Log("STUN");



        yield return new WaitForSeconds(.5f);

        //if(damageable.usePhysics)
        //{
        //    yield return new WaitForSeconds(.5f);
        //}
        //else
        //{
        //    yield return new WaitForSeconds(.1f);
        //}

        controller.enabled = true;
        if (lastState == PlayerState.Attacking)
        {
            state = PlayerState.Normal;
        }
        else
        {
            state = lastState;
        }
        Debug.Log("NORMAL");
    }

    IEnumerator ChangeArea(Vector2 a)
    {
        Vector3 areaPos = a;
        areaPos.z = Camera.main.transform.position.z;
        changearea = true;
        freeze = true;

        Time.timeScale = 0;


        currentArea.EnableEnemies();
        while (true)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, areaPos, Time.unscaledDeltaTime * camSpeed);


            if (Vector3.Distance(Camera.main.transform.position, areaPos) == 0)
            {
                break;
            }
            yield return new WaitForSecondsRealtime(0.01f);
        }

        if (lastArea != null)
        {
            lastArea.DisableEnemies();
        }

        lastArea = currentArea;

        changearea = false;
        freeze = false;
        Time.timeScale = 1;
        yield return null;
    }


    IEnumerator TeleportPlayer()
    {
        transform.position = tele.GetDestination();
        yield return null;
    }

    public void TalktoNPC()
    {
        this.enabled = false;
    }

    public void ExitTalkToNPC()
    {
        this.enabled = true;
    }
}
