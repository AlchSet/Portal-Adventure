using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonPossession : MonoBehaviour
{

    bool startPossessing;

    Transform target;
    public Animator anim;
    public Animator ai;

    bool b;
    // Start is called before the first frame update
    void Start()
    {
        ai = transform.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startPossessing&&!b)
        {
            if (Vector2.Distance(transform.position, target.position)<0.1f)
            {
                anim.SetBool("Possess", true);
                target.gameObject.SetActive(false);
                ai.SetTrigger("Continue");
                b = true;
                //this.enabled = false;
            }
        }
    }



    public void CheckIfPossessed()
    {
        if(b)
        {
            anim.SetBool("Possess", true);
            target.gameObject.SetActive(false);
            ai.SetTrigger("Continue");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("NPC"))
        {
            startPossessing = true;
            target = collision.transform;
            Debug.Log("POSSESS");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("NPC"))
        {
            startPossessing = true;

            Debug.Log("POSSESS");
        }
    }

}
