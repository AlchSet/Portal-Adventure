using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : WeaponBase
{
    public GameObject NorthBow, SouthBow, EastBow, WestBow;

    public GameObject Arrow;


    Rigidbody2D loadedArrow;


    Controller2D.Direction arrowDir;


    public AudioClip bowString;
    public AudioClip bowFire;

    AudioSource sfx;


    

    bool isfired;




    private void Awake()
    {

        controller = transform.root.GetComponent<Controller2D>();


        NorthBow.SetActive(false);
        SouthBow.SetActive(false);
        EastBow.SetActive(false);
        WestBow.SetActive(false);

        sfx = GetComponent<AudioSource>();


        maxAmmo = 10;
        currentAmmo = 10;
    }




    public override void Dispose()
    {
        Debug.Log("DISPOSE BOW");



        if (loadedArrow)
            Destroy(loadedArrow.gameObject);

        //switch (arrowDir)
        //{

        //    case Controller2D.Direction.North:

        //        loadedArrow.bodyType = RigidbodyType2D.Dynamic;
        //        loadedArrow.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        //        loadedArrow.transform.SetParent(null);
        //        break;


        //    case Controller2D.Direction.South:

        //        loadedArrow.bodyType = RigidbodyType2D.Dynamic;
        //        loadedArrow.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
        //        loadedArrow.transform.SetParent(null);
        //        break;

        //    case Controller2D.Direction.East:
        //        loadedArrow.bodyType = RigidbodyType2D.Dynamic;
        //        loadedArrow.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
        //        loadedArrow.transform.SetParent(null);

        //        break;

        //    case Controller2D.Direction.West:
        //        loadedArrow.bodyType = RigidbodyType2D.Dynamic;
        //        loadedArrow.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
        //        loadedArrow.transform.SetParent(null);

        //        break;
        //}
        controller.lockDirection = false;
        NorthBow.SetActive(false);
        SouthBow.SetActive(false);
        EastBow.SetActive(false);
        WestBow.SetActive(false);


        StartCoroutine(FireCooldown());
    }

    public override bool GetInUse()
    {
        throw new System.NotImplementedException();
    }

    public override void OnButtonDown()
    {


        if (!inAttack&&currentAmmo>0)
        {
            currentAmmo--;
            inAttack = true;
            sfx.PlayOneShot(bowString);
            controller.lockDirection = true;

            arrowDir = controller.faceDir;

            switch (controller.faceDir)
            {
                case Controller2D.Direction.North:

                    NorthBow.SetActive(true);
                    SouthBow.SetActive(false);
                    EastBow.SetActive(false);
                    WestBow.SetActive(false);

                    GameObject g = Instantiate(Arrow, NorthBow.transform.position, Quaternion.Euler(0, 0, 0));

                    loadedArrow = g.GetComponent<Rigidbody2D>();

                    g.transform.SetParent(NorthBow.transform);
                    break;

                case Controller2D.Direction.South:


                    NorthBow.SetActive(false);
                    SouthBow.SetActive(true);
                    EastBow.SetActive(false);
                    WestBow.SetActive(false);


                    g = Instantiate(Arrow, SouthBow.transform.position, Quaternion.Euler(0, 0, 180));

                    loadedArrow = g.GetComponent<Rigidbody2D>();

                    g.transform.SetParent(SouthBow.transform);


                    break;


                case Controller2D.Direction.West:

                    NorthBow.SetActive(false);
                    SouthBow.SetActive(false);
                    EastBow.SetActive(false);
                    WestBow.SetActive(true);


                    g = Instantiate(Arrow, WestBow.transform.position, Quaternion.Euler(0, 0, 90));

                    loadedArrow = g.GetComponent<Rigidbody2D>();

                    g.transform.SetParent(WestBow.transform);



                    break;


                case Controller2D.Direction.East:
                    NorthBow.SetActive(false);
                    SouthBow.SetActive(false);
                    EastBow.SetActive(true);
                    WestBow.SetActive(false);



                    g = Instantiate(Arrow, EastBow.transform.position, Quaternion.Euler(0, 0, -90));

                    loadedArrow = g.GetComponent<Rigidbody2D>();

                    g.transform.SetParent(EastBow.transform);



                    break;
            }
            OnAttack();
        }
    }

    public override void OnButtonUp()
    {
        if (inAttack && !isfired)
        {
            sfx.PlayOneShot(bowFire);
            loadedArrow.GetComponent<Projectile>().Fire(arrowDir);
            switch (arrowDir)
            {

                case Controller2D.Direction.North:

                    loadedArrow.bodyType = RigidbodyType2D.Dynamic;
                    loadedArrow.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                    loadedArrow.transform.SetParent(null);



                    break;


                case Controller2D.Direction.South:

                    loadedArrow.bodyType = RigidbodyType2D.Dynamic;
                    loadedArrow.AddForce(Vector2.down * 7, ForceMode2D.Impulse);
                    loadedArrow.transform.SetParent(null);
                    break;

                case Controller2D.Direction.East:
                    loadedArrow.bodyType = RigidbodyType2D.Dynamic;
                    loadedArrow.AddForce(Vector2.right * 7, ForceMode2D.Impulse);
                    loadedArrow.transform.SetParent(null);

                    break;

                case Controller2D.Direction.West:
                    loadedArrow.bodyType = RigidbodyType2D.Dynamic;
                    loadedArrow.AddForce(Vector2.left * 7, ForceMode2D.Impulse);
                    loadedArrow.transform.SetParent(null);

                    break;
            }
            NorthBow.SetActive(false);
            SouthBow.SetActive(false);
            EastBow.SetActive(false);
            WestBow.SetActive(false);




            controller.lockDirection = false;

            isfired = true;

            StartCoroutine(FireCooldown());
        }


         


    }

   IEnumerator FireCooldown()
    {

        yield return new WaitForSeconds(0.5f);

        inAttack = false;
        isfired = false;



    }
}
