using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public QuestType questType;
    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyDefeated()
    {
        if(questType == QuestType.Battle)
        currentAmount++;
    }
    public void ItemPickUp() 
    {
        if (questType == QuestType.Gathering)
        currentAmount++;
    }
}

public enum QuestType { Battle, Gathering }
