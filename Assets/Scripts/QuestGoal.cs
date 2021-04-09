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

    public void PickUpApple()
    {
        if (questType == QuestType.GatheringApple)
            currentAmount++;
    }

    public void PickUpStrawberry()
    {
        if (questType == QuestType.GatheringStrawberry)
            currentAmount++;
    }

    public void PickUpBlueberry()
    {
        if (questType == QuestType.GatheringBlueberry)
            currentAmount++;
    }

    public void PickUpFlower()
    {
        if (questType == QuestType.GatheringFlower)
            currentAmount++;
    }

    public void PickUpTool()
    {
        if (questType == QuestType.GatheringTool)
            currentAmount++;
    }

    public void PickUpWood()
    {
        if (questType == QuestType.GatheringWood)
            currentAmount++;
    }

    public void PickUpStone()
    {
        if (questType == QuestType.GatheringStone)
            currentAmount++;
    }

    public void PickUpMetal()
    {
        if (questType == QuestType.GatheringMetal)
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

public enum QuestType { Battle, 
                        Gathering , 
                        GatheringMushroom , 
                        GatheringApple ,
                        GatheringStrawberry ,
                        GatheringBlueberry ,
                        GatheringFlower ,
                        GatheringTool ,
                        GatheringWood ,
                        GatheringStone ,
                        GatheringMetal ,
                        BattleGoblin , 
                        BattleSlime}
