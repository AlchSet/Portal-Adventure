using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public Image[] items;
    public UnityEvent[] shopActions;

    public ShopItem[] shopItems;



    public int index;

    public bool delayer;

    public float X;


    public PlayerInput player;

    // Start is called before the first frame update
    void Start()
    {
        if(items.Length>0)
        {
            items[0].color = Color.yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {




        X = Input.GetAxisRaw("Horizontal");


        if(X!=0&&!delayer)
        {
            Debug.Log(X);

            index =(index + (int)X) % items.Length;
            if(index<0)
            {
                index = items.Length - 1;
            }
            StartCoroutine(delay());
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            if(player.Coins>=shopItems[index].cost)
            {
                Debug.Log(" BUY ITEM " + index);

                player.SubtractCoins(shopItems[index].cost);

                shopItems[index].action.Invoke();


            }
        }


        //else
        //{
        //    delayer = false;
        //}

       



    }


    public void EnableShop()
    {
        this.enabled = true;
    }


    public void DisableShop()
    {
        this.enabled = false;
    }


    public void UpdateSelection()
    {
        foreach(Image i in items)
        {
            i.color = Color.white;
        }

        items[index].color = Color.yellow;
    }

    IEnumerator delay()
    {
        delayer = true;
        UpdateSelection();
        yield return new WaitForSecondsRealtime(0.2f);
        delayer = false;

    }


    [System.Serializable]
    public class ShopItem 
    {
        public Image image;
        public int cost;
        public UnityEvent action;
    }

}
