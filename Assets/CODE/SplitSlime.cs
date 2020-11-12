using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitSlime : MonoBehaviour
{

    public GameObject parentSlime;
    public GameObject[] SmallSlimes;

    List<Vector2> SmallSlimesPos=new List<Vector2>();

    public Damageable d;



    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject g in SmallSlimes)
        {
            SmallSlimesPos.Add(g.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Split()
    {
        //parentSlime.SetActive(false);

        d.life = 2;
        foreach(GameObject g in SmallSlimes)
        {
            //g.transform.SetParent(null);

            g.SetActive(true);


            
        }
    }


    public void Reset()
    {
        int i = 0;
        foreach (GameObject g in SmallSlimes)
        {
            SmallSlimes[i].transform.position = SmallSlimesPos[i];

            g.SetActive(false);
            i++;
        }
    }





}
