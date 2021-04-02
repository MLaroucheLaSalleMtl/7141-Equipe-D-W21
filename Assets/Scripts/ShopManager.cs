using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{


    public int[,] shopItems = new int[5,5];
    public float coins;
    public Text CoinsTXT;
    public PlayerGoldExpLvl gold;
    public Stat items;
    // Start is called before the first frame update
    void Start()
    {
        CoinsTXT.text = "Coins: " + PlayerGoldExpLvl.goldOwned.ToString();

        //Item ID
        shopItems[1, 1]=1;
        shopItems[1, 2]=2;
        shopItems[1, 3]=3;
       

        //Items price
        shopItems[2, 1] = 20;
        shopItems[2, 2] = 40;
        shopItems[2, 3] = 30;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (PlayerGoldExpLvl.goldOwned >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            PlayerGoldExpLvl.goldOwned -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
          
            CoinsTXT.text = "Coins :" + PlayerGoldExpLvl.goldOwned.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            
        }
    }
}
