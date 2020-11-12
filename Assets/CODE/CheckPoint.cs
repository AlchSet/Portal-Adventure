using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static Vector2 lastPos;
    Transform player;

    public static bool hasCheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (hasCheckPoint)
            player.position = lastPos;
    }

    // Update is called once per frame
    void Update()
    {

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("CHECKPOINT Player");
            lastPos = transform.position;
            hasCheckPoint = true;
        }
    }
}
