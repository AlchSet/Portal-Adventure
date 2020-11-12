using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittablePhysics : MonoBehaviour {


    Rigidbody2D rigidbody;

    public Damageable dmgable;

    public float knockbackResist = 1;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	


    public void ActivatePhysics()
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        //Debug.Log("HIT");

    }

    public void DeActivatePhysics()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        

    }



    public void Hit()
    {
        //Debug.Log("HIT COMMAND");
        if(dmgable)
        {
            //Debug.Log("USE PHYSICS=" + dmgable.usePhysics);
            if(dmgable.usePhysics)
            {
                
                ActivatePhysics();
                rigidbody.velocity = Vector2.zero;
                Vector2 dir = (Vector2)transform.position - (Vector2)dmgable.info.position;
                //Debug.Log("BAMSASADSASDDSADSSDASASDDAS");
                rigidbody.AddForce(dir.normalized * (dmgable.info.knockbackForce-knockbackResist), ForceMode2D.Impulse);
            }
            else
            {
                rigidbody.velocity = Vector2.zero;
                //Debug.Log("WHERE ARE U GETTING FORCE FROM?");
                return;
            }
      
        }

        
    }

}
