using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ce script sert a gerer le Gold, l'Exp et le Level du joueur
/// Script fait par Émile Deslauriers et Marie-Lee Potvin
/// </summary>

public class PlayerGoldExpLvl : MonoBehaviour
{
    //Fait par Emile Deslauriers
    public static int goldOwned = 75; //variable pour gener le gold du joueur
    public static int expOwned = 0; //variable pour l'exp du joueur
    public static int expTotalToLevel = 300; //variable pour le nombre d'exp pour monter de niveau
    public static int expNeeded = 0; //variable pour l'exp qui manque avant de level up
    public static int lvlPlayer = 1; //variable pour gerer le niveau du joueur
    public Text goldCountTxt; //point vers le gold counter
    public Text lvlCount; //point vers le level counter

    public void Update() //Fait par Émile Deslauriers
    {
        goldCountTxt.text = "Gold: " + goldOwned + "g"; //affiche le current gold du jouer sur le UI
        lvlCount.text = "Level: " + lvlPlayer; //affiche le current level du jouer sur le UI
        expNeeded = expTotalToLevel - expOwned; //le exp needed pour level up est egal a l'exp par niveau - current exp

        //si le current exp du joueur est plus grand ou egal a l'exp par niveau et que le player level est en bas de 100
        if (expOwned >= expTotalToLevel && lvlPlayer < 100) 
        {
            expOwned -= expTotalToLevel; //current exp - exp pour level up
            lvlPlayer += 1; //current level +1
        }
    }
}
