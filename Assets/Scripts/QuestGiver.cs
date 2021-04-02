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
    public Text txtExpReward;

    public bool canInteract;

    void Start()
    {
        playerQuest = GameObject.Find("--PlayerQuestManager--").GetComponent<PlayerQuest>(); //important
        
        questWindow.SetActive(false);

        if (playerQuest.quest.questTitle == quest.questTitle)
        {
            quest.isActive = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true)
        {
            OpenQuestWindow();
        }
    }

    public void OpenQuestWindow() 
    {
        questWindow.SetActive(true);
        txtQuestTitle.text = quest.questTitle;
        txtQuestDesc.text = quest.questDescription;
        txtGoldReward.text = quest.goldReward.ToString();
        txtExpReward.text = quest.expReward.ToString();
    }

    public void AcceptQuest() 
    {
        if (playerQuest.quest.isActive == false)
        {
            questWindow.SetActive(false);
            quest.isActive = true;
            playerQuest.quest = quest;
        }
    }

    public void BtnTurnInQuest()
    {
        if (quest.questTitle == playerQuest.quest.questTitle)
        { 
        playerQuest.TurnInQuest();
        questWindow.SetActive(false);
        }
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            questWindow.SetActive(false);
        }
    }
}