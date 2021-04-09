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
    public GameObject followQuestWindow;

    public PlayerQuest playerQuest; //GetComponent ou Creer un singleton

    public Text txtOnQuestTitle;
    public Text txtOnQuestDesc;
    public Text txtOnQuestGoldReward;
    public Text txtOnQuestExpReward;
    public Text txtOnQuestGoal;

    public Text levelText;
    public Text expNeededText;
    

    public static PauseMenu instance = null;
    private GameManager manager; //reference vers le singleton
    

    // Start is called before the first frame update
    void Start()
    {
        playerQuest = GameObject.Find("--PlayerQuestManager--").GetComponent<PlayerQuest>();

        pauseMenu.gameObject.SetActive(false);
        imageMiniMap.gameObject.SetActive(false);
        levelPlayer.gameObject.SetActive(false);
        followQuestWindow.gameObject.SetActive(false);

        manager = GameManager.instance; //cache le gameManager

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
 
        levelText.text = "Level " + PlayerGoldExpLvl.lvlPlayer;
        expNeededText.text = PlayerGoldExpLvl.expNeeded + " exp";

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

    public void OnFollowQuest() 
    {
        followQuestWindow.gameObject.SetActive(true);

        txtOnQuestTitle.text = playerQuest.quest.questTitle;
        txtOnQuestDesc.text = playerQuest.quest.questDescription;
        txtOnQuestGoldReward.text = playerQuest.quest.goldReward.ToString();
        txtOnQuestExpReward.text = playerQuest.quest.expReward.ToString();
        txtOnQuestGoal.text = "Goal: " + playerQuest.quest.goal.currentAmount.ToString() + " / " + playerQuest.quest.goal.requiredAmount.ToString();
        Time.timeScale = 0;
    }

    public void OnCancelQuest() 
    {
        playerQuest.quest.goal.currentAmount = 0;
        playerQuest.quest.isActive = false;

        followQuestWindow.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    public void OnExitFollowQuest()
    {
        followQuestWindow.gameObject.SetActive(false);

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

    public void NoQuest() 
    {
        if(playerQuest.quest.isActive == false)
        {
            txtOnQuestTitle.text = "Following No Quest";
            txtOnQuestDesc.text = " ";
            txtOnQuestGoldReward.text = "X";
            txtOnQuestExpReward.text = "X";
            txtOnQuestGoal.text = "Goal: X";
        }
    }

    void Update()
    {
        NoQuest();

        if (playerQuest.quest.isActive == true)
        {
            txtOnQuestGoal.text = "Goal: " + playerQuest.quest.goal.currentAmount.ToString() + " / " + playerQuest.quest.goal.requiredAmount.ToString();
        }
    }
}
