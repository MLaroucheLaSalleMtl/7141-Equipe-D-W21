using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ce script sert a gerer le slider du Player Mana
/// Script fait par Emile Deslauriers
/// </summary>

public class PlayerMana : MonoBehaviour
{
    public Slider sliderPlayerMana; //point vers le slider de la mana du player

    public void ChangeMaxManaPlayer(int playerMana) //mettre a jour le niveau maximum de mana du player
    {
        sliderPlayerMana.maxValue = playerMana;
        sliderPlayerMana.value = playerMana;
    }
    public void ChangeManaPlayer(int playerMana) //mettre a jour le niveau de mana du player 
    {
        sliderPlayerMana.value = playerMana;
    }
}
