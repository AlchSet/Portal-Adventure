using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    PlayerInput p;
    bool inDash;

    Controller2D controller;


    public GameObject afterimages;


    public ParticleSystem particles;

    ParticleSystem.EmissionModule em;

    public int dashes=2;
    public int maxDash = 2;
    public float rechargeSeconds=3;
    public float rechargeTime=0;

    public SpriteRenderer d1;
    public SpriteRenderer d2;

    Color oC;
    Color tC;


    public AudioClip sfx;

    public AudioSource source;


    public SpriteRenderer r;


    public float DashSpeed = 8;

    public float DashTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<PlayerInput>();
        controller = GetComponent<Controller2D>();

        em = particles.emission;
        em.enabled = false;
        oC = d1.color;

        tC = new Color(oC.r, oC.g, oC.g, 0.5f);

        d1.enabled = false;
        d2.enabled = false;

        source = GetComponent<AudioSource>();

        r=transform.Find("PixelMan 1").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Jump")&&!inDash&&p.state==PlayerInput.PlayerState.Normal&&dashes>0)
        {
            dashes--;
            StartCoroutine(DashNow());
    
        }

        if(dashes<maxDash)
        {
           

            
            rechargeTime += Time.deltaTime;

            if(rechargeTime>=rechargeSeconds)
            {
                rechargeTime = 0;
                Debug.Log("CHAGe");
                dashes++;
            }
        }
   
        UpdateDashIndicator();



    }


    public void UpdateDashIndicator()
    {
        if(dashes < maxDash)
        {
            d1.enabled = true;
            d2.enabled = true;
            if (dashes==0)
            {
               
                d1.color = tC;
                d2.color = tC;
            }
            else
            {
                d1.color = oC;
                d2.color = tC;
            }
        }
        else
        {
            d1.enabled = false;
            d2.enabled = false;
        }
    }

    IEnumerator DashNow()
    {
        Debug.Log("DASH");
        source.PlayOneShot(sfx);
        p.freeze = true;
        p.state = PlayerInput.PlayerState.Attacking;
        controller.speed = DashSpeed;
        controller.InputVel = controller.LastInputVel;
        inDash = true;
        Coroutine c=StartCoroutine(GenerateAfterImages());
        em.enabled = true;
        rechargeTime = 0;
        yield return new WaitForSeconds(DashTime);

        p.freeze = false;
        p.state = PlayerInput.PlayerState.Normal;
        controller.speed = 3;
        Debug.Log("END DASH");
        
        em.enabled = false;
        StopCoroutine(c);
        yield return new WaitForSeconds(.05f);
        inDash = false;
    }


    IEnumerator GenerateAfterImages()
    {
        while(true)
        {
            GameObject g=Instantiate(afterimages, transform.position, Quaternion.identity);
            g.GetComponent<AfterImageFX>().Initiate(r);
            yield return new WaitForSeconds(0.01f);
        }
        
    }

}
