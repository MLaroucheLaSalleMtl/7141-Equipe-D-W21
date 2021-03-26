using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private PauseMenu pauseMenu; //reference vers le singleton
    private LevelSystem levelSyst; //reference vers le singleton
    private Level level; //reference vers le singleton

    //[SerializeField] private Text levelText;
    //public string preTextLevel = "Level ";
    //[SerializeField] private Text nextLevelText;
    //public string preTextNextLevel = "For the next level\nyou need (xp) : ";
    //private int xpNeeded;
    
    public GameObject endGame;
    public static int oldManDead = 0;

    //public void ShowLvlPlayer()
    //{
    //    pauseMenu.levelPlayer.gameObject.SetActive(true);
    //}

    public void EndGame()
    {
        endGame.gameObject.SetActive(true);
        StartCoroutine(Wait15seconds());
    }

    IEnumerator Wait15seconds()
    {
        yield return new WaitForSeconds(15);
        Application.Quit(); //Quit l'application
    }

    private void Awake() //pour pouvoir utiliser Hose
    {
        if (instance == null)
        { instance = this; }
        else
        {
            if (instance != this)   //s'il y a deja un gameManager, on le detruit
            { Destroy(this); }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //levelText.text = preTextLevel;
        //nextLevelText.text = preTextNextLevel;

        levelSyst = LevelSystem.instance; //cache le levelsystem
        level = Level.instance; //cache le level
        pauseMenu = PauseMenu.instance; //cache le gameManager
        endGame.gameObject.SetActive(false);
    }

    //public void AddTextLevel()
    //{
    //    xpNeeded = levelSyst.GetXpForLvl(level.currentLevel);
    //    xpNeeded = levelSyst.GetXpForLvl(LevelSystem.currentLevel);
    //    
    //    levelText.text = preTextLevel + level.currentLevel;
    //    levelText.text = preTextLevel + LevelSystem.currentLevel;
    //    nextLevelText.text = preTextLevel + xpNeeded.ToString("D5");
    //    
    //    levelText.text = preTextLevel + PlayerLvlUp.level.currentLevel.ToString("D2");
    //}

    // Update is called once per frame
    void Update()
    {
        //AddTextLevel();
        
        if (oldManDead == 1)
        {
            EndGame();
        }
    }
}
