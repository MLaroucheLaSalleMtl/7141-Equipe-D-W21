using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public PlayerQuest playerQuest;

    public GameObject questWindow;
    public Text txtQuestTitle;
    public Text txtQuestDesc;
    public Text txtGoldReward;

    void Start()
    {
        questWindow.SetActive(false);

    }
    public void OpenQuestWindow() 
    {
        questWindow.SetActive(true);

        txtQuestTitle.text = quest.questTitle;
        txtQuestDesc.text = quest.questDescription;
        txtGoldReward.text = quest.goldReward.ToString();
    }

    public void AcceptQuest() 
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        playerQuest.quest = quest;
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }
}
