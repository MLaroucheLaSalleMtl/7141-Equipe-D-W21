using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ce script sert a gerer le hud pour les objets, les spells et l'option de flee une bataille
/// Script fait par Emile Deslauriers
/// </summary>

public class HUDManager : MonoBehaviour
{
    public GameObject objectHUD; //pointe vers la fenetre des objets
    public GameObject spellHUD; //pointe vers la fenetre des spells
    public GameObject fleeHUD; //pointe vers la fenetre de flee

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; //le curseur peut etre bougé
        Cursor.visible = true; //le curseur est visible

        objectHUD.gameObject.SetActive(false); //desactive la fenetre d'objets
        spellHUD.gameObject.SetActive(false); //desactive la fenetre de spell
    }

    public void CloseWindow() //fermer tout les fenetres
    {
        objectHUD.gameObject.SetActive(false);
        spellHUD.gameObject.SetActive(false);
        fleeHUD.gameObject.SetActive(false);
    }

    public void OpenSpell() //ouvre la fenetre de Spell
    {
        objectHUD.gameObject.SetActive(false);
        spellHUD.gameObject.SetActive(true);
        fleeHUD.gameObject.SetActive(false);
    }

    public void OpenObject() //ouvre la fenetre d'objet
    {
        objectHUD.gameObject.SetActive(true);
        spellHUD.gameObject.SetActive(false);
        fleeHUD.gameObject.SetActive(false);
    }

    public void OpenFlee() //ouvre la fenetre de flee
    {
        objectHUD.gameObject.SetActive(false);
        spellHUD.gameObject.SetActive(false);
        fleeHUD.gameObject.SetActive(true);
    }
}
