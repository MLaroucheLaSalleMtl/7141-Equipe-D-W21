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
    public static int lvlPlayer = 1;
    public Text goldCountTxt;
    public Text lvlCount;
    public static int doWeAddXp = 0;

    public void Update()
    {
        goldCountTxt.text = "Gold: " + goldOwned + "g";
        lvlCount.text = "Level: " + lvlPlayer;

        if (doWeAddXp == 1)
        {
            AddXp();
            doWeAddXp = 0;
        }

        expNeeded = expTotalToLevel - expOwned;

        if (expOwned >= expTotalToLevel)
        {
            expOwned -= expTotalToLevel;
            lvlPlayer += 1;
            expTotalToLevel = expTotalToLevel * 2;
        }
    }

    public void AddXp()
    {
        expOwned += 50;
    }
}
