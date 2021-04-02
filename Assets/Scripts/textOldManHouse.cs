using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textOldManHouse : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    //public string dialogueDontSteal;
    //public string dialogueFirstTimeAction;
    //public string dialogueNotFirstTimeAction;
    public string dialogueFirstTime;
    public string dialogueNotFirstTime;
    public bool dialogueActive;
    public static int firstTime = 0;
    //public int textDontStealShowing = 0;

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
                if (firstTime == 0)
                {
                    dialogueBox.SetActive(true);
                    dialogueText.text = dialogueFirstTime;
                    firstTime = 1;

                    //dialogueText.text = dialogueDontSteal;
                    //textDontStealShowing = 1;
                    //if (Input.GetKeyDown(KeyCode.Space) && textDontStealShowing == 1)
                    //{
                    //    dialogueText.text = dialogueFirstTimeAction;
                    //    textDontStealShowing = 0;
                    //}
                }
                else
                {
                    dialogueBox.SetActive(true);
                    dialogueText.text = dialogueNotFirstTime;
                    
                    //dialogueText.text = dialogueDontSteal;
                    //textDontStealShowing = 1;
                    //if (Input.GetKeyDown(KeyCode.Space) && textDontStealShowing == 1)
                    //{
                    //    dialogueText.text = dialogueNotFirstTimeAction;
                    //    textDontStealShowing = 0;
                    //}
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
