using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellBombSequence : MonoBehaviour
{

    public List<GameObject> bombs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in transform)
        {
            bombs.Add(t.gameObject);
        }

        ActivateSequence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ActivateSequence()
    {
        StartCoroutine(BombSequence());
    }


    IEnumerator BombSequence()
    {
        foreach (GameObject g in bombs)
        {
            g.SetActive(true);

            yield return new WaitForSeconds(0.1f);
        }
    }

}
