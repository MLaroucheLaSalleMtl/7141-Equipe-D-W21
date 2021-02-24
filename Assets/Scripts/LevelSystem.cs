using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    private int level;
    private int exp;
    private int expToNextLvl;

    public LevelSystem()
    {
        level = 0;
        exp = 0;
        expToNextLvl = 100;
    }

    public void AddExp(int amount)
    {
        exp += amount;
        if (exp >= expToNextLvl)
        { 
            level++;
            exp -= expToNextLvl;
        }
    }

    public int GetLvlNumber()
    {
        return level;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
