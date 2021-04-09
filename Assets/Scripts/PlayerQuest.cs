using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public Quest quest;

    public void ItemQuestPickUp() 
    {
        if (quest.isActive)
        {
            quest.goal.ItemPickUp();
        }
    }

    public void MushroomPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpMushroom();
        }
    }

    public void StrawberryPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpStrawberry();
        }
    }

    public void ApplePickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpApple();
        }
    }

    public void BlueberryPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpBlueberry();
        }
    }

    public void FlowerPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpFlower();
        }
    }

    public void ToolPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpTool();
        }
    }

    public void WoodPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpWood();
        }
    }

    public void StonePickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpStone();
        }
    }

    public void MetalPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpMetal();
        }
    }

    public void BattleQuestWon()
    {
        if (quest.isActive)
        {
            quest.goal.EnemyDefeated();
        }
    }

    public void BattleGoblinWon()
    {
        if (quest.isActive)
        {
            quest.goal.GoblinDefeated();
        }
    }

    public void BattleSlimeWon()
    {
        if (quest.isActive)
        {
            quest.goal.SlimeDefeated();
        }
    }
    public void TurnInQuest()
    {
        if (quest.isActive)
        {
            if (quest.goal.IsReached())
            {
                PlayerGoldExpLvl.goldOwned += quest.goldReward;
                PlayerGoldExpLvl.expOwned += quest.expReward;
                quest.goal.currentAmount = 0;
                quest.Finished();
            }
        }
    }
}
