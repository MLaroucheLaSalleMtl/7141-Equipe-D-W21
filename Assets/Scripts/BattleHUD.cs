using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Ce script sert a update l'interface de combat (slider, hp, mana, level, nom)
/// Script fait par Emile Deslauriers
/// Source : Brackeys, Youtube, Turn-Based Combat in Unity, 24 nov 2019, 14:30 min
/// Lien youtube : https://www.youtube.com/watch?v=_1pz_ohupPs&ab_channel=Brackeys
/// </summary>

public class BattleHUD : MonoBehaviour
{
    public Text nameText; //pointe vers le nameText
    public Text levelText; //pointe vers le levelText
    public Text hpLevel; //pointe vers le hplevel
    public Text manaLevel; //pointe vers le manalevel
    public Slider hpSlider; //pointe vers le slider de health
    public Slider manaSlider; //pointe vers le slider de mana

    public void SetHUD(Stat stat) //update le HUD du player et du enemy pour changer le nom, level, slider hp et slider mana
    {
        nameText.text = stat.characterName; //fait reference a la variable characterName dans le script Stat
        levelText.text = "Lvl: " + stat.characterLevel; //fait reference a la variable characterLevel dans le script Stat

        hpLevel.text = stat.currentHp + "/" + stat.maxHp; //text pour voir le current hp / le max hp
        manaLevel.text = stat.currentMana + "/" + stat.maxMana; //text pour voir le current mana / le max mana

        hpSlider.maxValue = stat.maxHp; //fait reference a la variable maxHP dans le script Stat
        hpSlider.value = stat.currentHp; //fait reference a la variable currentMana dans le script Stat
        manaSlider.maxValue = stat.maxMana; //fait reference a la variable maxMana dans le script Stat
        manaSlider.value = stat.currentMana; //fait reference a la variable currentMana dans le script Stat
    }

    public void SetHP(int hp) //update le slider value de hp et le nombre de hp
    {
        hpSlider.value = hp; //hpSlider value est egale au HP
    }

    public void SetMana(int mana) //update le slider value de mana et le nombre de mana
    {
        manaSlider.value = mana; //manaSlider value est egale au Mana
    }
}
