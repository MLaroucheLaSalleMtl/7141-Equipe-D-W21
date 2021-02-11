using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider sliderPlayerHP; //point vers le slider de la vie du player

    public void ChangeMaxHealthPlayer(int playerHealth) //mettre a jour le niveau maximum de vie du player
    {
        sliderPlayerHP.maxValue = playerHealth;
        sliderPlayerHP.value = playerHealth;
    }
    public void ChangeHealthPlayer(int playerHealth) //mettre a jour le niveau de vie du player 
    {
        sliderPlayerHP.value = playerHealth;
    }
}
