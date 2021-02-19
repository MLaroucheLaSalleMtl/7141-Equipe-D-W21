using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu (fileName = "new Consumable", menuName ="Items/Consumables")]
public class Consumable : Item
{
    public int heal = 0;
    public int mana = 0;
    public int damage = 0;
    public override void Use()
    {
        GameObject player = Inventory.instance.player;
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

     
        Inventory.instance.Remove(this);
    }

   
    
}
