using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Code de base écrit par Kevin (Script : Sign)
// Modif apporté par Marie-Lee

public class textChest1 : MonoBehaviour
{
    //Fait par Kevin
    public GameObject dialogueBox;
    public Text dialogueText;
    public bool dialogueActive;

    //Fait par Marie-Lee
    public string dialogueChestClosed;
    public string dialogueChestOpen1;
    public string dialogueChestOpen2;
    public static int isTheChestOpen = 0;

    GameManager manager;
    
    public GameObject chestOpenAppear;
    public GameObject chestClosedDisappear;

    //public int goldCoin;
    //public int healthPotion;
    //public int manaPotion;

    //Fait par Marie-Lee
    public void ChestOpenAppear()
    {
        chestClosedDisappear.gameObject.SetActive(false);
        chestOpenAppear.gameObject.SetActive(true);
    }

    //Fait par Marie-Lee
    IEnumerator WaitXseconds(int seconds)
    {
        if (isTheChestOpen != 0)
        {
            yield return new WaitForSeconds(seconds);
            ChestOpenAppear();
        }
    }

    //Fait par Marie-Lee
    void Start()
    {
        manager = GameManager.instance; //cache le gameManager

        chestClosedDisappear.gameObject.SetActive(true);
        chestOpenAppear.gameObject.SetActive(false);
    }

    //Fait par Marie-Lee
    void Update()
    {
        //if (isTheChestOpen == 1 && dialogueActive)
        //{
        //    if (dialogueBox.activeInHierarchy)
        //    {
        //        dialogueBox.SetActive(false);
        //    }
        //    else
        //    {
        //        dialogueBox.SetActive(true);
        //        dialogueText.text = dialogueBefore;
        //        isTheChestOpen = 2;
        //    }
        //}
        //
        //else if (Input.GetKeyDown(KeyCode.Space) && dialogueActive && isTheChestOpen==2)
        //{
        //    if (dialogueBox.activeInHierarchy)
        //    {
        //        dialogueBox.SetActive(false);
        //    }
        //    else
        //    {
        //        dialogueBox.SetActive(true);
        //        dialogueText.text = dialogueAfter;
        //    }
        //}

        if (isTheChestOpen != 0)  //est-ce qu'on ouvre le coffre ou non
        {
            StartCoroutine(WaitXseconds(2));
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {

            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                dialogueBox.SetActive(true);
                if (isTheChestOpen == 0) //première fois qu'on interagit avec le coffre
                {
                    dialogueText.text = dialogueChestClosed;
                    isTheChestOpen = 1;
                }
                else if (isTheChestOpen == 1) //le coffre est maintenant ouvert
                {
                    dialogueText.text = dialogueChestOpen1;
                    isTheChestOpen = 2;
                    PlayerGoldExpLvl.goldOwned += 150;
                    //PlayerGoldExpLvl.goldOwned += goldCoin;
                }
                else //si le joueur interagit avec le coffre une 2e (ou plus) fois
                {
                    dialogueText.text = dialogueChestOpen2;
                }
            }
        }
    }

    //Fait par Kevin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueActive = true;
        }
    }

    //Fait par Kevin
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            dialogueActive = false;
            dialogueBox.SetActive(false);
        }
    }

}
