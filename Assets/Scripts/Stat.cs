using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour //script dans le but d'attribue des stats a des personnages
{
    public string characterName; //variable string public pour le Nom
    public int characterLevel; //variable int public pour le niveau

    public int damagePerTurn; //variable int public pour le nombre de damage par tour
    public int healPerTurn; //variable int public pour le nombre de vie par tour

    public int maxHp; //variable int public pour le maximum hp
    public int currentHp; //varriable int public pour le hp actuel

    public int maxMana; //variable int public pour le maximum mana
    public int currentMana; //variable int public pour la mana actuelle

    public bool TakeDamage(int dmg) //fonction bool qui enleve de la vie et qui retourne si le hp est en bas de 0
    {
        currentHp -= dmg; //moins de vie sur le damagePerTurn
        if (currentHp <= 0) //si la vie est egal ou en bas de 0 retourn TRUE
        {
            return true;
        }
        else //sinon retourne FALSE
        {
            return false;
        }
    }

    public void Heal(int heals) //fonction qui redonne de la vie
    {
        //*faire en sorte de reduire le nombre de potions
        currentHp += heals; //current hp + healPerTurn
        if (currentHp > maxHp) //si le current hp va en haut de la vie normale
        {
            currentHp = maxHp; //remet la vie a 100%
        }
    }
}
