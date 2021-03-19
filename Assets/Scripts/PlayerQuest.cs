using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public Quest quest;

    public GameObject questWindown;

    public void ItemQuestPickUp() 
    {
        quest.goal.ItemPickUp();
    }

    public void BattleWon()
    {
        quest.goal.EnemyDefeated();
    }
    public void TurnInQuest()
    {
        if (quest.isActive)
        {
            if (quest.goal.IsReached())
            {
                PlayerGold.goldOwned += quest.goldReward;
                //exp here
                quest.goal.currentAmount = 0;
                quest.Finished();
                questWindown.SetActive(false);
            }
        }
    }
}
