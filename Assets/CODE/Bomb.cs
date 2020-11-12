using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    Animator anim;

    public float Duration;

    float elapsed;

    bool hasExploded;

    ParticleSystem p;

    AudioSource sfx;

    public LayerMask hitLayers;


    public float range = 2;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponentInChildren<Animator>();
        p = GetComponentInChildren<ParticleSystem>();
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        anim.SetFloat("tick", Mathf.Lerp(1, 5, elapsed / Duration));

        if(elapsed>=Duration&&!hasExploded)
        {
            anim.Play("Bomb Explode");
            hasExploded = true;
            p.Emit(50);

            Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, range, hitLayers);

            Damageable.CollisionInfo i = new Damageable.CollisionInfo();

            i.totalDmg = 3;
            i.knockbackForce = 6;
            i.position = transform.position;
            sfx.PlayOneShot(sfx.clip);

            foreach(Collider2D t in targets)
            {
                t.GetComponent<Damageable>().DealDamage(i);


            }
            StartCoroutine(CleanUp());
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    IEnumerator CleanUp()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
