using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGold : MonoBehaviour
{
    public static int goldOwned = 0;
    public Text goldCountTxt;


    public void FixedUpdate()
    {
        goldCountTxt.text = "Gold: " + goldOwned + "g";
    }
}
