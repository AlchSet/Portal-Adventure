using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Encounter : MonoBehaviour
{

    public Damageable enemy;


    //public UnityEvent result;

    // Start is called before the first frame update
    void Start()
    {
        enemy.OnDeath.AddListener(CheckEncounterState);
    }

    
    public void CheckEncounterState()
    {
        //Debug.Log("CHECK STATE");


        if(enemy.life<=0)
        {
            Debug.Log("GATE IS OPEN");

            gameObject.SetActive(false);
        }


    }
}
