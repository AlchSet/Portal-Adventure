using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : WeaponBase
{
    public GameObject Bullet;
    public Transform player;
    AudioSource sfx;

    public float delay=0.5f;


    public GameObject owner;

    public Damageable ownerDMG;
    private void Awake()
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
        StartCoroutine(ChargeFireball());
    }

    public override void OnButtonUp()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator ChargeFireball()
    {

        OnAttack();

        sfx.PlayOneShot(sfx.clip);
        GameObject f = Instantiate(Bullet, transform.position, Quaternion.identity);
        f.GetComponent<Projectile>().owner = ownerDMG;
        yield return new WaitForSeconds(0.1f);

        f.GetComponent<Collider2D>().enabled = true;
        Vector2 dir = player.position- transform.position;


        f.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 8,ForceMode2D.Impulse);

        yield return new WaitForSeconds(delay);

        OnExitAttack();



        //f.transform.localScale = Vector3.zero;

        //float i = 0;

        //while(true)
        //{
        //    i += Time.deltaTime;
        //    f.transform.localScale = Vector3.MoveTowards(transform.transform.localScale, Vector3.one, i);


        //    if(i>=1)
        //    {
        //        break;
        //    }

        //    yield return new WaitForEndOfFrame();

        //}



        yield return null;
    }

}
