using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public string sceneMenu = "Scene Menu Principale";

    public GameObject imageMiniMap;
    public GameObject pauseMenu;
    public GameObject levelPlayer;

    //private GameManager manager; //reference vers le singleton

    private LevelSystem levelSyst; //reference vers le singleton
    [SerializeField] private Text levelText;
    public string preTextLevel = "Level ";
    [SerializeField] private Text nextLevelText;
    public string preTextNextLevel = "For the next level\nyou need (xp) : ";
    private int xpNeeded;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
        imageMiniMap.gameObject.SetActive(false);
        levelPlayer.gameObject.SetActive(false);

        //manager = GameManager.instance; //cache le gameManager
        levelText.text = preTextLevel;
        nextLevelText.text = preTextNextLevel;
        
        levelSyst = LevelSystem.instance; //cache le levelsystem

        Time.timeScale = 1;
    }

    public void OnMiniMap()
    {
            imageMiniMap.gameObject.SetActive(true);

            Time.timeScale = 0;
    }

    public void OnMiniMapClose() 
    {
        imageMiniMap.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    public void OnLevelPlayer()
    {
        xpNeeded = levelSyst.GetXpForLvl(levelSyst.currentLevel);
        levelText.text = preTextLevel + levelSyst.currentLevel;
        nextLevelText.text = preTextLevel + xpNeeded.ToString("D5");
        //manager.AddTextLevel(); //ajoute le texte
        levelPlayer.gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    public void OnLevelPlayerClose()
    {
        levelPlayer.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    public void OnPause()
    {
        pauseMenu.gameObject.SetActive(true);
        
        Time.timeScale = 0;
    }

    public void OnResume()
    {
        pauseMenu.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    public void MainMenu() 
    {
        SceneManager.LoadScene(sceneMenu); //Load la scene principale
    }

    public void ExitGame()
    {
        Application.Quit(); //Quit l'application
    }
}
