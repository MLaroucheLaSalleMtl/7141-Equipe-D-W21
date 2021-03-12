using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSystem
{
    public int experience;
    public int currentLevel;
    public Action OnLvlUp;

    public int maxExp;
    public int maxLevel = 99;

    public LevelSystem(int level, Action OnLevUp)
    {
        maxExp = GetXpForLvl(maxLevel);
        currentLevel = level;
        experience = GetXpForLvl(level);
        OnLvlUp = OnLevUp;
    }

    public int GetXpForLvl(int level)
    {
        if (level > maxLevel)
            return 0;

        int firstPass = 0;
        int secondPass = 0;
        for (int lvlCycle = 1; lvlCycle < level; lvlCycle++)
        {
            firstPass += (int)Math.Floor(lvlCycle + (300.0f * Math.Pow(2.0f, lvlCycle / 7.0f)));
            secondPass = firstPass / 4;
        }
        if (secondPass > maxExp && maxExp != 0)
            return maxExp;
        if (secondPass < 0)
            return maxExp;

        return secondPass;
    }

    public int GetLvlForXp(int exp)
    {
        if (exp > maxExp)
            return maxExp;

        int firstPass = 0;
        int secondPass = 0;
        for (int lvlCycle = 1; lvlCycle <= maxLevel; lvlCycle++)
        {
            firstPass += (int)Math.Floor(lvlCycle + (300.0f * Math.Pow(2.0f, lvlCycle / 7.0f)));
            secondPass = firstPass / 4;

            if (secondPass > exp)
                return lvlCycle;
        }
        if (exp > secondPass)
            return maxLevel;

        return 0;
    }

    public bool AddXp(int amount)
    {
        if (amount + experience < 0 || experience > maxExp)
        {
            if (experience > maxExp)
                experience = maxExp;
            return false;
        }

        int oldLvl = GetLvlForXp(experience);
        experience += amount;
        if (oldLvl < GetLvlForXp(experience))
        {
            if (currentLevel < GetLvlForXp(experience))
            {
                currentLevel = GetLvlForXp(experience);
                if (OnLvlUp != null)
                    OnLvlUp.Invoke();
                return true;
            }
        }
        return false;
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
