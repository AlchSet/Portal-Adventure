using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{


    public bool isActive;

    public Vector3 boxSize = Vector3.one;


    GameObject owner;

    public LayerMask target;

    public ParticleSystem hitFX;


    public WeaponBase rootWPN;
    

    // Use this for initialization
    void Start()
    {
        owner = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {


        if (isActive)
        {

            
             Collider2D[] d = Physics2D.OverlapBoxAll(transform.position, boxSize, Vector2.Angle(Vector2.up,transform.up),target);
            //Debug.Log(transform.eulerAngles.z);
            //Debug.Log(d.Length);

            foreach (Collider2D o in d)
            {

                //Debug.Log(o.name);
                if(o.gameObject!=owner)
                {
                    if(o.tag!="Rock")
                    {
                        Damageable.CollisionInfo i = new Damageable.CollisionInfo();
                        //i.position = transform.position;
                        i.position = owner.transform.position;

                        i.totalDmg = 1;
                        i.knockbackForce = rootWPN.knockbackforce;
                        o.GetComponent<Damageable>().DealDamage(i);
                        //hitFX.transform.position = o.transform.position;
                        //hitFX.Emit(20);
                    }

                    //if(o.gameObject.layer==LayerMask.NameToLayer("Enemy"))
                    //{
                    //    if(hitFX)
                    //    {
                    //        hitFX.transform.position = o.transform.position;
                    //        hitFX.Emit(20);
                    //    }
                    
                    //}
                    //o.GetComponent<Damageable>().DealDamage(1);


                }
                
            }

        }
        else
        {

        }

    }


    private void OnDrawGizmos()
    {

        Color c = Color.red;
        c.a = 0.5f;

        Gizmos.color = c;

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

        Gizmos.DrawCube(Vector3.zero, new Vector3(boxSize.x * 2, boxSize.y * 2, boxSize.z * 2)); // Because size is halfExtents
    }



  
}
