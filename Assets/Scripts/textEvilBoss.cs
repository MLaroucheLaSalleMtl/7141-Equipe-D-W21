using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Code de base écrit par Kevin N.-R. (Script : Sign)
// Modif apporté par Marie-Lee P.

public class textEvilBoss : MonoBehaviour
{
    //Fait par Kevin
    public GameObject dialogueBox;
    public Text dialogueText;
    public string dialogue;
    public bool dialogueActive;
    
    //Fait par Marie-Lee
    public static int oldManCombatBegin = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    //Fait par Marie-Lee
    IEnumerator Wait5seconds()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Scene Combat Boss");
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
                oldManCombatBegin = 1;
                dialogueBox.SetActive(true);
                dialogueText.text = dialogue;
                StartCoroutine(Wait5seconds());
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
