using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public GameObject objectHUD; //Pointe Vers le menu Option
    public GameObject spellHUD; //Pointe Vers le menu MainMenu

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; //Le curseur peut etre bougé
        Cursor.visible = true; //Le curseur est Visible

        objectHUD.gameObject.SetActive(false);
        spellHUD.gameObject.SetActive(false);
    }

    public void CloseWindow()
    {
        objectHUD.gameObject.SetActive(false);
        spellHUD.gameObject.SetActive(false);
    }
    public void OpenSpell()
    {
        objectHUD.gameObject.SetActive(false);
        spellHUD.gameObject.SetActive(true);
    }
    public void OpenObject()
    {
        objectHUD.gameObject.SetActive(true);
        spellHUD.gameObject.SetActive(false);
    }
}
