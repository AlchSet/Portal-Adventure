using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleFireBal : WeaponBase
{


    public GameObject Bullet;
    public Transform player;
    AudioSource sfx;

    public float delay = 0.5f;


    public GameObject owner;

    public Damageable ownerDMG;

    public Transform pointA, pointB, pointC;



    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sfx = GetComponent<AudioSource>();
        owner = transform.root.gameObject;
    }

    public override void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public override bool GetInUse()
    {
        throw new System.NotImplementedException();
    }

    public override void OnButtonDown()
    {
        StartCoroutine(FireBallsAttack());
    }

    public override void OnButtonUp()
    {
        throw new System.NotImplementedException();
    }


    IEnumerator FireBallsAttack()
    {
        OnAttack();

        sfx.PlayOneShot(sfx.clip);
        GameObject f = Instantiate(Bullet, pointB.position, Quaternion.identity);
        f.GetComponent<Projectile>().owner = ownerDMG;

        GameObject f2 = Instantiate(Bullet, pointA.position, Quaternion.identity);

        GameObject f3 = Instantiate(Bullet, pointC.position, Quaternion.identity);

        f2.GetComponent<Projectile>().owner = ownerDMG;
        f3.GetComponent<Projectile>().owner = ownerDMG;


        yield return new WaitForSeconds(0.1f);

        f.GetComponent<Collider2D>().enabled = true;
        f2.GetComponent<Collider2D>().enabled = true;
        f3.GetComponent<Collider2D>().enabled = true;




        Vector2 dir = player.position - transform.position;


        Vector2 dir2 = Quaternion.Euler(0, 0, 25) * dir;
        Vector2 dir3 = Quaternion.Euler(0, 0, -25) * dir;


        f.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 8, ForceMode2D.Impulse);

        f2.GetComponent<Rigidbody2D>().AddForce(dir3.normalized * 8, ForceMode2D.Impulse);

        f3.GetComponent<Rigidbody2D>().AddForce(dir2.normalized * 8, ForceMode2D.Impulse);

        yield return new WaitForSeconds(delay);

        OnExitAttack();

        yield return null;
    }
}
