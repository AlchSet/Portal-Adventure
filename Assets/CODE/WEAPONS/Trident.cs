using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trident : WeaponBase
{


    private void Start()
    {
        controller = transform.root.GetComponent<Controller2D>();
    }

    private void Update()
    {
        switch(controller.faceDir)
        {
            case Controller2D.Direction.North:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;

            case Controller2D.Direction.South:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            case Controller2D.Direction.East:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;

            case Controller2D.Direction.West:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;


        }
    }

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
        throw new System.NotImplementedException();
    }

    public override void OnButtonUp()
    {
        throw new System.NotImplementedException();
    }

    
}
