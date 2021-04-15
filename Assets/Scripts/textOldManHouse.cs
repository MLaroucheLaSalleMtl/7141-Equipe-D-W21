using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Code de base écrit par Kevin (Script : Sign)
// Modif apporté par Marie-Lee

public class textOldManHouse : MonoBehaviour
{
    //Fait Kevin
    public GameObject dialogueBox;
    public Text dialogueText;
    public bool dialogueActive;

    //Fait par Marie-Lee
    public string dialogueFirstTime;
    public string dialogueNotFirstTime;
    public static int firstTime = 0;
    //public string dialogueDontSteal;
    //public string dialogueFirstTimeAction;
    //public string dialogueNotFirstTimeAction;
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
            
            //Fait par Marie-Lee
            else
            {
                if (firstTime == 0) //première fois qu'on parle au vieillard dans la maison
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
                else  //si ce n'est pas la première fois qu'on lui parle, le texte n'est plus le même qu'avant
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
