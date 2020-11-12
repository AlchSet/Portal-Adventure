using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCollectable : MonoBehaviour
{
    public List<LootItem> loot = new List<LootItem>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void DropLoot()
    {
        LootItem item = loot[RandomItem()];

        Instantiate(item.item, transform.position, Quaternion.identity);
        //Debug.Log(item.item.ToString());
    }



    private int RandomItem()
    {
        int range = 0;

        foreach(LootItem i in loot)
        {
            range += i.weight;
        }

        int rand = Random.Range(0, range);
        int top = 0;

        int o = 0;
        
        for(int y=0;y<loot.ToArray().Length;y++)
        {
            top += loot[y].weight;
            if (rand < top)
            {
                o = y;
                break;
            }
        }
        return o;
    }

    [System.Serializable]
    public class LootItem
    {
        public GameObject item;
        public int weight;


    }
}
