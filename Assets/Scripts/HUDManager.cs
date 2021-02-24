using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public GameObject objectHUD; //point vers la fenetre des objets
    public GameObject spellHUD; //pointe vers la fenetre des spells
    public GameObject fleeHUD;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; //le curseur peut etre bougé
        Cursor.visible = true; //le curseur est visible

        objectHUD.gameObject.SetActive(false); //desactive la fenetre d'objets
        spellHUD.gameObject.SetActive(false); //desactive la fenetre de spell
    }

    public void CloseWindow()
    {
        objectHUD.gameObject.SetActive(false);
        spellHUD.gameObject.SetActive(false);
        fleeHUD.gameObject.SetActive(false);
    }

    public void OpenSpell()
    {
        objectHUD.gameObject.SetActive(false);
        spellHUD.gameObject.SetActive(true);
        fleeHUD.gameObject.SetActive(false);
    }

    public void OpenObject()
    {
        objectHUD.gameObject.SetActive(true);
        spellHUD.gameObject.SetActive(false);
        fleeHUD.gameObject.SetActive(false);
    }

    public void OpenFlee()
    {
        objectHUD.gameObject.SetActive(false);
        spellHUD.gameObject.SetActive(false);
        fleeHUD.gameObject.SetActive(true);
    }
}
