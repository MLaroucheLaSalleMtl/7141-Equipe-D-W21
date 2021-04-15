using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce script sert a pickup l'objet Apple pour les quests
/// Script fait par Emile Deslauriers basé sur la logique du script Sign de Kevin De Nobrega-Rodrigues
/// </summary>

public class PickUpApple : MonoBehaviour
{
    public PlayerQuest playerQuest; //fait reference au PlayerQuest

    public bool canInteract; //variable bool pour interagir

    void Start()
    {
        playerQuest = GameObject.Find("--PlayerQuestManager--").GetComponent<PlayerQuest>(); //GetComponent GameObject --PlayerQuestManager--
    }

    void Update()
    {
        //si le joueur appuie sur Space bar, Interact egale a true et Goal egal a Gathering ou GatheringApple
        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true && (playerQuest.quest.goal.questType == QuestType.GatheringApple || playerQuest.quest.goal.questType == QuestType.Gathering))
        {
            playerQuest.ItemQuestPickUp(); //appelle la fonction ItemQuestPickUp du script PlayerQuest
            playerQuest.ApplePickUp(); //appelle la fonction ApplePickUp du script PlayerQuest
            Destroy(gameObject); //detruit le GameObject
        }
    }

    void OnTriggerEnter2D(Collider2D collision) //collision enter
    {
        if (collision.CompareTag("Player")) //si tag est Player
        {
            canInteract = true; //true
        }
    }

    void OnTriggerExit2D(Collider2D collision) //collision exit
    {

        if (collision.CompareTag("Player")) //si le tag est player
        {
            canInteract = false; //false
        }
    }
}
