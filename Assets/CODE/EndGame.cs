using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public Damageable boss;

    public Transform whitescreen;

    public AudioSource endMusic;

    // Start is called before the first frame update
    void Start()
    {
        boss.OnDeath.AddListener(EndIt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EndIt()
    {
        endMusic.Stop();
        StartCoroutine(EndGameSequence());
    }


    IEnumerator EndGameSequence()
    {

        while(true)
        {
            whitescreen.localScale = Vector3.MoveTowards(whitescreen.localScale, new Vector3(100, 100, 100), Time.deltaTime*100);
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }



}
