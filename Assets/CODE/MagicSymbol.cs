using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MagicSymbol : MonoBehaviour
{

    public Damageable[] enemies;


    public float lives;


    public ParticleSystem p;

    public UnityEvent OnCompleteQuest;


    public static int pi = 2;


    // Start is called before the first frame update
    void Start()
    {
        lives = enemies.Length;

        foreach(Damageable d in enemies)
        {
            d.OnDeath.AddListener(DamageMe);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageMe()
    {
        lives--;

        if(lives<=0)
        {
            //OnCompleteQuest.Invoke();


            pi--;


            if(pi<=0)
            {
                OnCompleteQuest.Invoke();
            }

            Debug.Log("HELL FIRE");
            p.Stop();
            gameObject.SetActive(false);
        }
    }
}
