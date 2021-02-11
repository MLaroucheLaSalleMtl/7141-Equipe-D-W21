using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour //script dans le but d'attribue des stat a des personnages
{
    public string characterName; //variable string public pour le Nom
    public int characterLevel; //variable int public pour le niveau

    public int damagePerTurn; //variable int public pour le nombre de damage par tour

    public int maxHp; //variable int public pour le maximum hp
    public int currentHp; //varriable int public pour le hp actuel

    public int maxMana; //variable int public pour le maximum mana
    public int currentMana; //variable int public pour la mana actuelle
}
