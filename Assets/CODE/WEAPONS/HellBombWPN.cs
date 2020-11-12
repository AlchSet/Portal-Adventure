using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellBombWPN : WeaponBase
{

    public GameObject[] HellBombs;

    public Vector2 SpawnPoint;


    public override void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public override bool GetInUse()
    {
        throw new System.NotImplementedException();
    }

    public override void OnButtonDown()
    {

        int r = Random.Range((int)0, (int)HellBombs.Length);

        GameObject g = Instantiate(HellBombs[r], SpawnPoint, Quaternion.identity);
    }

    public override void OnButtonUp()
    {
        throw new System.NotImplementedException();
    }

    
}
