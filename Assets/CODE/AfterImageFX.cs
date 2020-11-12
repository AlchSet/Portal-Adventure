using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageFX : MonoBehaviour
{

    public SpriteRenderer playerSprite;

    public SpriteRenderer renderer;



    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();

        //playerSprite = GameObject.FindGameObjectWithTag("Player").transform.Find("PixelMan 1").GetComponent<SpriteRenderer>();

        //renderer.sprite = playerSprite.sprite;

        //transform.position = playerSprite.transform.position;
        //StartCoroutine(Flicker());
    }

    // Update is called once per frame
    public void Initiate(SpriteRenderer s)
    {
        playerSprite = s;
        renderer.sprite = playerSprite.sprite;
        transform.position = playerSprite.transform.position;
        StartCoroutine(Flicker());
    }


    IEnumerator Flicker()
    {
        float t = 0;
        while (t <= .3f)
        {
            renderer.enabled = !renderer.enabled;
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        renderer.enabled = false;
        Destroy(gameObject);
        yield return null;
    }


}
