using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ce script sert a gerer le slider du Enemie Mana
/// Script fait par Emile Deslauriers
/// </summary>

public class EnemyMana : MonoBehaviour
{
    public Slider sliderEnemyMana; //point vers le slider de la mana enemy

    public void ChangeMaxManaEnemy(int enemyMana) //mettre a jour le niveau maximum de mana enemy
    {
        sliderEnemyMana.maxValue = enemyMana;
        sliderEnemyMana.value = enemyMana;
    }
    public void ChangeManaEnemy(int enemyMana) //mettre a jour le niveau de mana enemy
    {
        sliderEnemyMana.value = enemyMana;
    }
}
