using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageController : MonoBehaviour
{

    public GameObject imageFX;

    public SpriteRenderer r;

    Coroutine c;

    public void StartFX()
    {
        c = StartCoroutine(GenerateAfterImages());
    }


    public void StopFX()
    {
        StopCoroutine(c);
    }


    // Start is called before the first frame update


    IEnumerator GenerateAfterImages()
    {
        while (true)
        {
            GameObject g = Instantiate(imageFX, transform.position, Quaternion.identity);
            g.GetComponent<AfterImageFX>().Initiate(r);
            yield return new WaitForSeconds(0.01f);
        }

    }

}
