using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject btnReturn; //Pointe vers le button Return
    public GameObject menuMainMenu; //Pointe Vers le menu MainMenu
    public GameObject menuHowToPlay; //Pointe Vers le menu How To Play
    public GameObject menuStory; //Pointe vers le menu Story
    public GameObject menuControl; //Pointe vers le menu Control
    public GameObject menuOption; //Pointe Vers le menu Option
    
    public string sceneStart = "Scene Principale"; //Point vers la scene principale

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; //Le curseur peut etre bougé
        Cursor.visible = true; //Le curseur est Visible

        btnReturn.gameObject.SetActive(false); //Button MainMenu est Invisible/Désactiver
        menuHowToPlay.gameObject.SetActive(false); //GameObject pour le Menu How To Play est Invisible/Desactiver
        menuOption.gameObject.SetActive(false); //GameObject pour le Menu Option est Invisible/Desactiver
        menuMainMenu.gameObject.SetActive(true); //GameObject pour le Menu Option est Visible/Activer
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneStart); //Load la scene principale
        PlayerPrefs.SetFloat("PlayerX", -3.52f); 
        PlayerPrefs.SetFloat("PlayerY", -10.89f);
        PlayerPrefs.SetFloat("PlayerZ", 0f);
    }

    public void Option()
    {
        btnReturn.gameObject.SetActive(true);
        menuHowToPlay.gameObject.SetActive(false);
        menuOption.gameObject.SetActive(true);
        menuMainMenu.gameObject.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        btnReturn.gameObject.SetActive(false);
        menuHowToPlay.gameObject.SetActive(false);
        menuOption.gameObject.SetActive(false);
        menuMainMenu.gameObject.SetActive(true);
    }

    public void HowToPlay()
    {
        btnReturn.gameObject.SetActive(true);
        menuHowToPlay.gameObject.SetActive(true);
        menuStory.gameObject.SetActive(true);
        menuControl.gameObject.SetActive(false);
        menuOption.gameObject.SetActive(false);
        menuMainMenu.gameObject.SetActive(false);
    }

    public void Story()
    {
        menuStory.gameObject.SetActive(true);
        menuControl.gameObject.SetActive(false);
    }

    public void Control()
    {
        menuStory.gameObject.SetActive(false);
        menuControl.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit(); //Quit l'application
    }
}
