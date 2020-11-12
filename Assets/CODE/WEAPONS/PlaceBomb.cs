using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBomb : WeaponBase
{
    public GameObject bombItem;

    public Transform bposNorth, bposSouth, bposEast, bposWest;



    private void Awake()
    {
        maxAmmo = 3;
        currentAmmo = 3;
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

        if(currentAmmo>0)
        {
            currentAmmo--;
            OnAttack();
            GameObject g = Instantiate(bombItem);
            switch (controller.faceDir)
            {
                case Controller2D.Direction.North:

                    g.transform.position = bposNorth.position;

                    break;


                case Controller2D.Direction.South:
                    g.transform.position = bposSouth.position;
                    break;


                case Controller2D.Direction.East:
                    g.transform.position = bposEast.position;

                    break;



                case Controller2D.Direction.West:

                    g.transform.position = bposWest.position;
                    break;


            }
        }
      
    }

    public override void OnButtonUp()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = transform.root.GetComponent<Controller2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
