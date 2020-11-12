using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    Animator anim;

    public Damageable dmg;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartBurning()
    {
        anim.Play("Burning");

        StartCoroutine(Burn());
    }


    IEnumerator Burn()
    {
        yield return new WaitForSeconds(3);
        dmg.DealDamage(1);
        anim.Play("Default");

    }



}
