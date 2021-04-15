using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce script sert a pickup l'objet Metal pour les quests
/// Script fait par Emile Deslauriers basé sur le script PickUpApple
/// </summary>

public class PickUpMetal : MonoBehaviour
{
    public PlayerQuest playerQuest;

    public bool canInteract;

    void Start()
    {
        playerQuest = GameObject.Find("--PlayerQuestManager--").GetComponent<PlayerQuest>(); //important
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true && playerQuest.quest.goal.questType == QuestType.GatheringMetal)
        {
            playerQuest.MetalPickUp();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
