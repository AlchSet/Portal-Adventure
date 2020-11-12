using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public PlayerInput player;

    Text goldText;





    private void Start()
    {
        player.OnCollectCoin += UpdateCoinLabel;

        goldText = GetComponent<Text>();
    }


    public void UpdateCoinLabel(int coins)
    {
        goldText.text =""+ player.Coins;

        Debug.Log(player.Coins);

    }




}
