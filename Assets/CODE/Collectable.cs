using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{

    SpriteRenderer sprite;

    Collider2D col;

    public bool isDropped;

    public UnityEvent OnCollect;

    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

        sprite.enabled = false;

        col = GetComponent<Collider2D>();

        col.enabled = false;


        if (isDropped)
            Drop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Drop()
    {
        sprite.enabled = true;
        col.enabled = true;
        isDropped = true;
        transform.SetParent(null);
    }





    
}
