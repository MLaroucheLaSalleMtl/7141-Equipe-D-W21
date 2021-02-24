using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleHUD : MonoBehaviour
{
    public Text nameText; //point vers le nameText
    public Text levelText; //point vers le levelText
    public Text hpLevel;
    public Text manaLevel;
    public Slider hpSlider; //point vers le slider de health
    public Slider manaSlider; //point vers le slider de mana

    public void SetHUD(Stat stat) //update le HUD du player et du enemy pour changer le nom, level, slider hp et slider mana
    {
        nameText.text = stat.characterName; //fait reference a la variable characterName dans le script Stat
        levelText.text = "Lvl: " + stat.characterLevel; //fait reference a la variable characterLevel dans le script Stat

        hpLevel.text = stat.currentHp + "/" + stat.maxHp;
        manaLevel.text = stat.currentMana + "/" + stat.maxMana;

        hpSlider.maxValue = stat.maxHp; //fait reference a la variable maxHP dans le script Stat
        hpSlider.value = stat.currentHp; //fait reference a la variable currentMana dans le script Stat
        manaSlider.maxValue = stat.maxMana; //fait reference a la variable maxMana dans le script Stat
        manaSlider.value = stat.currentMana; //fait reference a la variable currentMana dans le script Stat
    }

    public void SetHP(int hp) //update le slider value de hp et le nombre de hp
    {
        hpSlider.value = hp;
    }

    public void SetMana(int mana) //update le slider value de mana et le nombre de mana
    {
        manaSlider.value = mana;
    }
}
