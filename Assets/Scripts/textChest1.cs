using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChest1 : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public string dialogueChestClosed;
    public string dialogueChestOpen1;
    public string dialogueChestOpen2;
    public static int isTheChestOpen = 0;
    public bool dialogueActive;

    //public int goldCoin;
    //public int healthPotion;
    //public int manaPotion;

    GameManager manager;

    public GameObject chestOpenAppear;
    public GameObject chestClosedDisappear;


    public void ChestOpenAppear()
    {
        chestClosedDisappear.gameObject.SetActive(false);
        chestOpenAppear.gameObject.SetActive(true);
    }

    IEnumerator Wait4seconds(int seconds)
    {
        if (isTheChestOpen != 0)
        {
            yield return new WaitForSeconds(seconds);
            ChestOpenAppear();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance; //cache le gameManager

        chestClosedDisappear.gameObject.SetActive(true);
        chestOpenAppear.gameObject.SetActive(false);
    }

    // Update is called once per frame
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

        if (isTheChestOpen != 0)
        {
            StartCoroutine(Wait4seconds(2));
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
                if (isTheChestOpen == 0)
                {
                    dialogueText.text = dialogueChestClosed;
                    isTheChestOpen = 1;
                }
                else if (isTheChestOpen == 1)
                {
                    dialogueText.text = dialogueChestOpen1;
                    isTheChestOpen = 2;
                    PlayerGoldExpLvl.goldOwned += 50;
                    //PlayerGoldExpLvl.goldOwned += goldCoin;
                }
                else
                {
                    dialogueText.text = dialogueChestOpen2;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            dialogueActive = false;
            dialogueBox.SetActive(false);
        }
    }

}
