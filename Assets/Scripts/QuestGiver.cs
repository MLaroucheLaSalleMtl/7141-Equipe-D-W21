using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ce script sert a gerer les quest donnés par le NPC
/// Script fait par Emile Deslauriers
/// Source : Brackeys, Youtube, QUESTING SYSTEM in Unity!, 10 fev. 2019, 5:00 min
/// Lien youtube : https://www.youtube.com/watch?v=e7VEe_qW4oE&ab_channel=Brackeys
/// </summary>

public class QuestGiver : MonoBehaviour
{
    public Quest quest; //reference au script Quest

    public PlayerQuest playerQuest; //reference au script PlayerQuest

    public GameObject questWindow; //reference au GameObjet questWindow

    public Text txtQuestTitle; //text pour le titre de la quest
    public Text txtQuestDesc; //text pour la description de la quest
    public Text txtGoldReward; //text pour le montant de gold donner par la quest
    public Text txtExpReward; //text pour le montant d'exp donner par la quest

    public bool canInteract; //variable bool pour etre capable d'interagir avec le NPC

    void Start()
    {
        //get component le GameObject au nom de --PlayerQuestManager--
        playerQuest = GameObject.Find("--PlayerQuestManager--").GetComponent<PlayerQuest>();
        
        questWindow.SetActive(false); //questWindow devien invisible

        if (playerQuest.quest.questTitle == quest.questTitle && playerQuest.quest.isActive == true) //si la quest suivit par le player a le meme nom que la quest
        {
            quest.isActive = true; //quest is active
        }
        else 
        {
            quest.isActive = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true) //si bool est true et que le joueur appui sur space bar
        {
            OpenQuestWindow(); //appel la fonction OpenQuestWindow
        }
        quest.goal.currentAmount = playerQuest.quest.goal.currentAmount;
    }

    public void OpenQuestWindow() //fonction pour ouvrir la quest window
    {
        questWindow.SetActive(true); //quest window visible
        txtQuestTitle.text = quest.questTitle; //txt pour le titre de la quest
        txtQuestDesc.text = quest.questDescription; //txt pour la description de la quest
        txtGoldReward.text = quest.goldReward.ToString(); //txt pour le gold reward de la quest
        txtExpReward.text = quest.expReward.ToString(); //txt pour le exp reward de la quest
    }

    public void BtnAcceptQuest() //fonction pour accepter la quest
    {
        if (playerQuest.quest.isActive == false) //si le player n'a pas de quest active
        {
            questWindow.SetActive(false); //quest window invisible
            quest.isActive = true; //quest devient active
            playerQuest.quest = quest; //la quest du player devient la quest donner par le npc
        }
    }

    public void BtnTurnInQuest() //fonction pour turn in la quest
    {
        //si le title de la quest du player est le meme que la questi et le goal est reached
        if (quest.questTitle == playerQuest.quest.questTitle && quest.goal.IsReached())
        { 
        playerQuest.TurnInQuest(); //appel la fonction TurnInQuest du script PlayerQuest
        quest.isActive = false;
        questWindow.SetActive(false); //quest window invisible
        }
    }

    public void BtnCloseQuestWindow() //fonction pour fermer la quest window
    {
        questWindow.SetActive(false); //quest window invisible
    }

    private void OnTriggerEnter2D(Collider2D collision) //collider enter
    {
        if (collision.CompareTag("Player")) //si le tag est Player
        {
            canInteract = true; //met la variable bool canInteract a true
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //collider exit
    {

        if (collision.CompareTag("Player")) //si le tag est Player
        {
            canInteract = false; //met la variable bool canInteract a false
            questWindow.SetActive(false); //questWindow devient invisible
        }
    }
}