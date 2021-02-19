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

       // playerHealth.Heal(heal);
        Inventory.instance.Remove(this);
    }

   /* public void Revive()
    {
        if(currentHealth == 0)
        {
            currentHealth = maxHealth
        }
    }
   */

   /* public void Heal()
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            maxHealth = currentHealth;
        }

        healthbar.value = currentHealth / maxHealth;

    } */

  /*  public void ManaHeal()
    {
        currentMana += amount;
        if(currentMana> maxMana)
        {
            maxMana = currentMna;
        }
        mpbar.value = currentMana / maxMana;
    }*/

   /* public void ItemDamage()
    {
        currentItem = amount;
        if (currentItem > EnemyHealth)
        {
            EnemyHealth = 0;
        }
    }*/
}
