using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{

    public WeaponBase AmmoWeapon;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        if(AmmoWeapon)
        {
            AmmoWeapon.OnAttack += UpdateUI;
            AmmoWeapon.OnAddAmmo += UpdateUI;
            UpdateUI();
        }
        
    }


    public void UpdateUI()
    {
        text.text = "" + AmmoWeapon.currentAmmo;
    }

}
