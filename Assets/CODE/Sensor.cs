using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{

    Animator ai;

    public GameObject player;

    public float detectRange = 5;


    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            float d = Vector2.Distance(player.transform.position, transform.position);

            if(d<detectRange)
            {
                ai.SetBool("DetectPlayer", true);
            }
            else
            {
                ai.SetBool("DetectPlayer", false);
            }
        }
    }
}
