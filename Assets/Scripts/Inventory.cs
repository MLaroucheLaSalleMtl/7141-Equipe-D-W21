using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script cr��e par Kevin De Nobrega-Rodrigues
public class Inventory : MonoBehaviour
{
    public static int healthPotion = 0;         //On retrouve ici les objets qu'on peut acheter en les mettant static pour les r�utiliser et l'impl�menter dans le 
                                                //ShopManager et BattleManager qui va r�f�rer � ce script pour les items qu'on peut utiliser
    public static int manaPotion = 0;           //Dont Health Potion pour la vie, Mana Potion pour le mana et Fire Flower pour un montant de damage fixe.
    public static int fireFlower = 0;
    public static int healthPotionPrice = 20;
    public static int manaPotionPrice = 40;
    public static int fireFlowerPrice = 30;
    public static int healthPotionQuantity= 0;
    public static int manaPotionQuantity = 0;
    public static int fireFlowerQuantity = 0;
}
