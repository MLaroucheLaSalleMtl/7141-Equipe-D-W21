using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private PauseMenu pauseMenu; //reference vers le singleton
    
    //private LevelSystem levelSyst; //reference vers le singleton
    //private Level level; //reference vers le singleton

    //[SerializeField] private Text levelText;
    //public string preTextLevel = "Level ";
    //[SerializeField] private Text nextLevelText;
    //public string preTextNextLevel = "For the next level\nyou need (xp) : ";
    //private int xpNeeded;
    
    public GameObject caveIsVisible;
    
    public GameObject endGameStory;
    public GameObject endGameCredits;
    public static int oldManDead = 0;
    public int whichPanelEndGame = 0;

    //public GameObject chestOpenAppear;
    //public GameObject chestClosedDisappear;

    //public void ShowLvlPlayer()
    //{
    //    pauseMenu.levelPlayer.gameObject.SetActive(true);
    //}

    //public void ChestOpenAppear()
    //{
    //    chestClosedDisappear.gameObject.SetActive(false);
    //    chestOpenAppear.gameObject.SetActive(true);
    //}

    public void CaveIsVisible()
    {
        caveIsVisible.gameObject.SetActive(true);
    }


    public void EndGameStory()
    {
        endGameStory.gameObject.SetActive(true);
        StartCoroutine(WaitXseconds(15));
    }

    public void EndGameCredits()
    {
        endGameStory.gameObject.SetActive(false);
        endGameCredits.gameObject.SetActive(true);
        whichPanelEndGame = 1;
        StartCoroutine(WaitXseconds(7));
    }

    IEnumerator WaitXseconds(int seconds)
    {
        if (whichPanelEndGame == 0)
        {
            yield return new WaitForSeconds(seconds);
            EndGameCredits();
        }
        else
        {
            yield return new WaitForSeconds(seconds);
            Application.Quit(); //Quit l'application
        }
    }

    //IEnumerator Wait4seconds(int seconds)
    //{
    //    if (textChest.isTheChestOpen != 0)
    //    {
    //        yield return new WaitForSeconds(seconds);
    //        ChestOpenAppear();
    //    }
    //}

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

        //levelSyst = LevelSystem.instance; //cache le levelsystem
        //level = Level.instance; //cache le level
        pauseMenu = PauseMenu.instance; //cache le gameManager

        caveIsVisible.gameObject.SetActive(false);
        
        endGameStory.gameObject.SetActive(false);
        endGameCredits.gameObject.SetActive(false);

        //chestClosedDisappear.gameObject.SetActive(true);
        //chestOpenAppear.gameObject.SetActive(false);
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

        //if (textChest.isTheChestOpen != 0)
        //{
        //    StartCoroutine(Wait4seconds(4));
        //}

        if (oldManDead == 1)    //si on a vaincu le evil boss, le paneau de fin du jeu s'affiche
        {
            EndGameStory();
        }

        if (textOldManHouse.firstTime == 1)     //après avoir parlé avec le ptit vieux dans la maison, la grotte est maintenant visible/on peut y aller
        {
            CaveIsVisible();
        }
    }
}
