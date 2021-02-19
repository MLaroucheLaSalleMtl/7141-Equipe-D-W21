using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChest : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public string dialogueBefore;
    public string dialogueAfter;
    public bool dialogueActive;
    int isTheChestIsOpen = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {

            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                dialogueBox.SetActive(true);
                if (isTheChestIsOpen == 0)
                {
                    dialogueText.text = dialogueBefore;
                    isTheChestIsOpen = 1;
                }
                else
                { 
                    dialogueText.text = dialogueAfter;
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
