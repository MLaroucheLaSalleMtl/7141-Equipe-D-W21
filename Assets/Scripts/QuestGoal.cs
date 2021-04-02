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
    public void PickUpMushroom()
    {
        if (questType == QuestType.GatheringMushroom)
        currentAmount++;
    }

    public void GoblinDefeated()
    {
        if (questType == QuestType.BattleGoblin)
        currentAmount++;
    }

    public void SlimeDefeated()
    {
        if (questType == QuestType.BattleSlime)
            currentAmount++;
    }
}

public enum QuestType { Battle, Gathering , GatheringMushroom , BattleGoblin , BattleSlime}
