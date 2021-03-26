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

    public void BattleQuestWon()
    {
        if (quest.isActive)
        {
            quest.goal.EnemyDefeated();
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
