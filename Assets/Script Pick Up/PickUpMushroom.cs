using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce script sert a pickup l'objet Mushroom pour les quests
/// Script fait par Emile Deslauriers bas� sur le script PickUpApple
/// </summary>

public class PickUpMushroom : MonoBehaviour
{
    public PlayerQuest playerQuest;

    public bool canInteract;

    void Start()
    {
        playerQuest = GameObject.Find("--PlayerQuestManager--").GetComponent<PlayerQuest>(); //important
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true && (playerQuest.quest.goal.questType == QuestType.GatheringMushroom || playerQuest.quest.goal.questType == QuestType.Gathering))
        {
            playerQuest.ItemQuestPickUp();
            playerQuest.MushroomPickUp();
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
