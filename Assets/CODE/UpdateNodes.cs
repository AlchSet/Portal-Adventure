using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateNodes : MonoBehaviour
{
    Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        bounds = GetComponent<Collider2D>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Rescan()
    {

        //AstarPath.active.Scan();
        AstarPath.active.UpdateGraphs(bounds);
    }
}
