using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Ce script sert a gerer le shop et les items acheter a partir du montant de gold du joueur
/// Script fait par Kevin De Nobrega-Rodrigues et Émile Deslauriers en pair programming
/// </summary>

public class ShopManager : MonoBehaviour
{
    public Text CoinsTXT;
   
    // Start is called before the first frame update
    void Start() //Fait par Kevin De Nobrega-Rodrigues
    {
        CoinsTXT.text = "Coins: " + PlayerGoldExpLvl.goldOwned.ToString();//Affiche le gold du joueur en se référant dans le script Stat pour savoir combien de gold le joueur a en ce moment.
    }

    public void BuyManaPotion() 
    {
        //Fait par Émile Deslauriers
        if (PlayerGoldExpLvl.goldOwned >= Inventory.manaPotionPrice)
        {
            Inventory.manaPotionQuantity++;
            Inventory.manaPotion++;
            PlayerGoldExpLvl.goldOwned -= Inventory.manaPotionPrice;

            //Fait par Kevin De Nobrega-Rodrigues
            CoinsTXT.text="Coins: " + PlayerGoldExpLvl.goldOwned.ToString();
        }
    }
    public void BuyHealthPotion()
    {
        //Fait par Émile Deslauriers
        if (PlayerGoldExpLvl.goldOwned >= Inventory.healthPotionPrice)
        {
            Inventory.healthPotionQuantity++;
            Inventory.healthPotion++;
            PlayerGoldExpLvl.goldOwned -= Inventory.healthPotionPrice;

            //Fait par Kevin De Nobrega-Rodrigues
            CoinsTXT.text = "Coins: " + PlayerGoldExpLvl.goldOwned.ToString();
        }
    }
    public void BuyFireFlower()
    {
        //Fait par Émile Deslauriers
        if (PlayerGoldExpLvl.goldOwned >= Inventory.fireFlowerPrice)
        {
            Inventory.fireFlowerQuantity++;
            Inventory.fireFlower++;
            PlayerGoldExpLvl.goldOwned -= Inventory.fireFlowerPrice;

            //Fait par Kevin De Nobrega-Rodrigues
            CoinsTXT.text = "Coins: " + PlayerGoldExpLvl.goldOwned.ToString();
        }
    }
}
