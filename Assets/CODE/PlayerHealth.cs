using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Damageable playerHealth;

    public GameObject HealthIcon;


    public List<Image> img=new List<Image>();

    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = playerHealth.life;
        img.Add(HealthIcon.GetComponent<Image>());
        for(int i=1;i<12;i++)
        {
            GameObject g=Instantiate(HealthIcon, transform);
            img.Add(g.GetComponent<Image>());
           
        }
        UpdateHealth();

        playerHealth.OnHit.AddListener(UpdateHealth);
        playerHealth.OnHealed.AddListener(UpdateHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateHealth()
    {
        Debug.Log(playerHealth.life);

        foreach(Image i in img)
        {
            i.enabled = false;
        }


        for(int i=0;i<playerHealth.life; i++)
        {
            img[i].enabled = true;
        }
    }
}
