using System.Collections;
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

    private LevelSystem levelSyst; //reference vers le singleton
    [SerializeField] private Text levelText;
    public string preTextLevel = "Level ";
    [SerializeField] private Text nextLevelText;
    public string preTextNextLevel = "Pour le prochain\nniveau : ";

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
        imageMiniMap.gameObject.SetActive(false);
        levelPlayer.gameObject.SetActive(false);

        levelText.text = preTextLevel;
        nextLevelText.text = preTextNextLevel;

        levelSyst = LevelSystem.instance;

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
        levelPlayer.gameObject.SetActive(true);
        levelText.text = preTextLevel + levelSyst.currentLevel;
        nextLevelText.text = preTextLevel + levelSyst.experience + "/" + levelSyst.maxExp;

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
