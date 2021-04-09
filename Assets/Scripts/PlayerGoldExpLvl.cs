using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGoldExpLvl : MonoBehaviour
{
    public static int goldOwned = 0;
    public static int expOwned = 0;
    public static int expTotalToLevel = 100;
    public static int expNeeded = 0;
    public static int lvlPlayer = 1; //niveau 1
    public Text goldCountTxt;
    public Text lvlCount;
    public static int doWeAddXp = 0;
    public static int aLvlUp = 0;

    public void Update()
    {
        goldCountTxt.text = "Gold: " + goldOwned + "g";
        lvlCount.text = "Level: " + lvlPlayer;

        expNeeded = expTotalToLevel - expOwned;

        if (expOwned >= expTotalToLevel && lvlPlayer < 100)
        {
            expOwned -= expTotalToLevel;
            lvlPlayer += 1;
            aLvlUp = 1;
            expTotalToLevel = expTotalToLevel * 2;
        }
    }
}
