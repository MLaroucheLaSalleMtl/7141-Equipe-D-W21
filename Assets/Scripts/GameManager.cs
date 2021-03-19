using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    private LevelSystem levelSyst; //reference vers le singleton
    [SerializeField] private Text levelText;
    public string preTextLevel = "Level ";
    [SerializeField] private Text nextLevelText;
    public string preTextNextLevel = "For the next level\nyou need (xp) : ";
    private int xpNeeded;

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
        levelText.text = preTextLevel;
        nextLevelText.text = preTextNextLevel;

        levelSyst = LevelSystem.instance; //cache le levelsystem
    }

    public void AddTextLevel()
    {
        xpNeeded = levelSyst.GetXpForLvl(levelSyst.currentLevel);

        levelText.text = preTextLevel + levelSyst.currentLevel;
        nextLevelText.text = preTextLevel + xpNeeded.ToString("D5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
