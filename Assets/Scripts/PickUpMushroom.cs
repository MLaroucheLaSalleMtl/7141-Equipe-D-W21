using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true && playerQuest.quest.goal.questType == QuestType.GatheringMushroom)
        {
            playerQuest.MushroomPickUp();
            Destroy(gameObject);
        }
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
        }
    }
}
