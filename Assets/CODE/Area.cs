using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public List<EnemyAI> enemies = new List<EnemyAI>();


    private void Start()
    {
        DisableEnemies();
    }


    public void EnableEnemies()
    {
        foreach(EnemyAI g in enemies)
        {
            if(g.dmg.life<=0)
            {
                g.gameObject.SetActive(false);
            }
            else
            {
                g.gameObject.SetActive(true);

                g.Reset();
            }

           
        }

    }


    public void DisableEnemies()
    {
        foreach (EnemyAI g in enemies)
        {
            g.gameObject.SetActive(false);
        }

    }
}
