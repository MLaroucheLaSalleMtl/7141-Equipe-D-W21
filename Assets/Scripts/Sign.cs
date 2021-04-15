using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour  //Fait par Kevin De Nobrega-Rodrigues
                                   //Basé sur le script dans le lien suivant à partir de 19:10 : https://www.youtube.com/watch?v=1NCvpZDtTMI&t=712s
{
    public GameObject dialogueBox;      //Boîte de dialogue qu'on veut insérer pour mettre le texte
    public Text dialogueText;           //Texte qu'on met dans le dialogue
    public string dialogue;
    public bool dialogueActive;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& dialogueActive)  //On appuie sur la touche espace et ça fait apparaître le dialogue du Npc ou du panneau qu'on souhaite
        {
            
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);           //Laisse le dialogue désactivé si on n'appuie pas la touche espace
            }
            else
            {
                dialogueBox.SetActive(true);            //Mets le dialogue actif si on appuie espace
                dialogueText.text = dialogue;   
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
