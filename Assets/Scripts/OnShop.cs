using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnShop : MonoBehaviour                 //Script par Kevin De Nobrega-Rodrigues
{
    public GameObject shopBox;
                                                    //Utilise le m�me concept que le script Sign o� on fait appara�tre le dialogue pour int�ragir avec les npc
    public bool shopOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && shopOn)  //On appuie sur la touche espace et �a fait appara�tre le shop o� on ach�te les items avec le gold du joueur
        {

            if (shopBox.activeInHierarchy)
            {
                shopBox.SetActive(false); //Laisse le shop d�sactiv� si on n'appuie pas la touche espace
            }
            else
            {
                shopBox.SetActive(true);//Mets le shop actif si on appuie espace
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))         //Si on est devant le NPC, on est capable d'appuyer sur la touche espace pour faire appara�tre le shop
        {
            shopOn = true;                  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopOn = false;
            shopBox.SetActive(false);   //Fait dispara�tre le shop si on se d�place hors du NPC qui g�re le shop
        }
    }

}
