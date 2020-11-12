using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemies : MonoBehaviour
{

    public Damageable[] enemies;


    public void Respawn()
    {
        foreach(Damageable d in enemies)
        {
            d.life = d.maxLife;



        }



    }

}
