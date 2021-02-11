using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider sliderEnemyHP; //point vers le slider de la vie enemy

    public void ChangeMaxHealthEnemy(int enemyHealth) //mettre a jour le niveau maximum de vie enemy
    {
        sliderEnemyHP.maxValue = enemyHealth;
        sliderEnemyHP.value = enemyHealth;
    }
    public void ChangeHealthEnemy(int enemyHealth) //mettre a jour le niveau de vie enemy
    {
        sliderEnemyHP.value = enemyHealth;
    }
}
