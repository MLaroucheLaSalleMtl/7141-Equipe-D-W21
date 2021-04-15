using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce script sert a gerer les stats des entity pour le combat
/// Script fait par Emile Deslauriers
/// Source : Brackeys, Youtube, Turn-Based Combat in Unity, 24 nov 2019, 6:15 min
/// Lien youtube : https://www.youtube.com/watch?v=_1pz_ohupPs&ab_channel=Brackeys
/// </summary>

public class Stat : MonoBehaviour //script dans le but d'attribue des stats a des personnages
{
    public string characterName; //variable string public pour le Nom
    public int characterLevel; //variable int public pour le niveau

    public int basicDamage; //variable int public pour le nombre de damage par tour

    public int spellVenemousSpitDmg; //variable int public pour le dmg de Venemous Spit
    public int spellVenemousSpitMana; //variable int public pour mana de Venemous Spit
    public int spellWaterballDmg; //variable int public pour le dmg de Water Ball
    public int spellWaterballMana; //variable int public pour mana de Water Ball
    public int spellMudThrowDmg; //variable int public pour le dmg de Mud Throw
    public int spellMudThrowMana; //variable int public pour la mana de Mud Throw
    public int healthPotionPoints; //variable int public pour le nombre de point de vie
    public int manaPotionPoints; //variable int public pour le  nombre de point de mana
    public int fireFlowerDamage; //variable int public pour le dmg de Fire Flower

    public int maxHp; //variable int public pour le maximum hp
    public int currentHp; //varriable int public pour le hp actuel

    public int maxMana; //variable int public pour le maximum mana
    public int currentMana; //variable int public pour la mana actuelle

    public bool TakeDamage(int dmg) //fonction bool qui enleve de la vie et qui retourne si le hp est en bas de 0
    {
        currentHp -= dmg; //moins de vie sur le damagePerTurn
        if (currentHp <= 0) //si la vie est egal ou en bas de 0 retourn TRUE
        {
            currentHp = 0; //met le current hp a 0
            return true; //retourne true
        }
        else //sinon
        {
            return false; //retourne false
        }
    }

    public void OnHeal(int healUP) //fonction qui redonne de la vie
    {   
        currentHp += healUP; //current hp + healPerTurn
        Inventory.healthPotion -= 1;
        if (currentHp > maxHp) //si le current hp va en haut de la vie normale
        {
            currentHp = maxHp; //remet la vie a 100%
        }
    }

    public void OnMana(int manaUP) //fonction qui redonne de la vie 
    {
        currentMana += manaUP; //current hp + healPerTurn
        Inventory.manaPotion -= 1;
        if (currentMana > maxMana) //si le current hp va en haut de la vie normale
        {
            currentMana = maxMana; //remet la vie a 100%
        }
    }
}
