using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{



    public UnityEvent CleanUp;

    public bool hurtenemies;


    public bool LimitDistance;

    Vector2 firePos;

    public float limit;

    Collider2D box;

    bool fired;

    public bool arc;

    public Controller2D.Direction direction;

    public Damageable owner;

    public bool TimedDestroy;


    public Transform hitObject;


    Rigidbody2D body;


    public bool hurtBreakable;
    private void Awake()
    {
        box = GetComponent<Collider2D>();
        body = GetComponent<Rigidbody2D>();

    }


    public void Fire()
    {
        firePos = transform.position;
        fired = true;
        box.enabled = true;
    }

    public void Fire(Controller2D.Direction dir)
    {
        firePos = transform.position;
        fired = true;
        box.enabled = true;
        direction = dir;
    }


    void FixedUpdate()
    {
        if (LimitDistance && fired)
        {
            float d = Vector2.Distance(firePos, transform.position);
            float i = 0;
            i = d / limit;
            if (arc)
            {
                switch (direction)
                {
                    case Controller2D.Direction.North:


                        transform.rotation = Quaternion.Euler(Vector3.Lerp(Vector3.zero, new Vector3(0, 0, -15), i));

                        break;


                    case Controller2D.Direction.South:

                        transform.rotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0, 0, 180), new Vector3(0, 0, 195), i));


                        break;


                    case Controller2D.Direction.East:

                        transform.rotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0, 0, -90), new Vector3(0, 0, -105), i));


                        break;

                    case Controller2D.Direction.West:

                        transform.rotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0, 0, 90), new Vector3(0, 0, 105), i));


                        break;


                }
            }



            if (d >= limit)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log(collision.name);


        hitObject = collision.transform;

        if (hurtenemies)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Damageable"))
            {
                Debug.Log("HURT ENEMY");

                Damageable.CollisionInfo i = new Damageable.CollisionInfo();


                i.position = transform.position;
                i.knockbackForce = 1;
                i.totalDmg = 1;

                collision.gameObject.GetComponent<Damageable>().DealDamage(i);

                //Destroy(gameObject);
                CleanUp.Invoke();
            }


        }

        if (collision.gameObject.layer != LayerMask.NameToLayer("TransparentFX")
            && collision.gameObject.layer != LayerMask.NameToLayer("Collectable")
            && collision.gameObject.layer != LayerMask.NameToLayer("Bounds")
            //&& collision.gameObject.layer != LayerMask.NameToLayer("Damageable")
            )
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Damageable"))
            {
                if (collision.GetComponent<Damageable>() == owner)
                {
                    //Debug.Log("HITTING SLEF");
                }
                else
                {

                    
                    if(collision.gameObject.tag=="Enemy")
                    {

                    }
                    else
                    {
                        Damageable.CollisionInfo i = new Damageable.CollisionInfo();


                        i.position = transform.position;
                        i.knockbackForce = 1;
                        i.totalDmg = 1;

                        collision.gameObject.GetComponent<Damageable>().DealDamage(i);

                        //Destroy(gameObject);
                        CleanUp.Invoke();

                        Debug.Log("DEAL DMG");
                    }

                   

                }
            }
            else
            {
                if(collision.tag!="Projectile")
                {
                    CleanUp.Invoke();
                }
                if(collision.tag=="Arrow")
                {
                    Debug.Log("Hit Arrow");
                    Destroy(collision.gameObject);
                    CleanUp.Invoke();
                }

                //Destroy(gameObject);
                
            }

        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Breakable"))
        {
            if (hurtBreakable)
            {
                Damageable.CollisionInfo i = new Damageable.CollisionInfo();

                i.position = transform.position;
                i.knockbackForce = 1;
                i.totalDmg = 1;

                collision.gameObject.GetComponent<Damageable>().DealDamage(i);

                //Destroy(gameObject);
                CleanUp.Invoke();
            }
            else
            {
                //Destroy(gameObject);
                CleanUp.Invoke();
            }
        }



    }



    public void DestroySelf()
    {
        Destroy(gameObject);
    }





    public void DelayedDeactivate(float seconds)
    {
        StartCoroutine(DeactivateAfterSecond(seconds));
    }



    IEnumerator DeactivateAfterSecond(float s)
    {
        yield return new WaitForSeconds(s);
        gameObject.SetActive(false);
    }

    public void DelayedStopRigidbody(float seconds)
    {
        StartCoroutine(StopRigidbodyAfterSecond(seconds));
    }



    IEnumerator StopRigidbodyAfterSecond(float s)
    {
        yield return new WaitForSeconds(s);
        body.bodyType = RigidbodyType2D.Kinematic;
        HaltVelocity();
        //gameObject.SetActive(false);
    }


    public void AttachToTarget()
    {
        transform.SetParent(hitObject);
    }


    public void HaltVelocity()
    {
        body.velocity = Vector2.zero;

    }
}
