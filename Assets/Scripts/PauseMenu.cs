using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Ce script sert a gerer l'interface du Pause Menu
/// Script fait par Emile Deslauriers avec quelques parties fait par Marie-Lee Potvin
/// </summary>

public class PauseMenu : MonoBehaviour
{
    //fait par Emile Deslauriers
    public string sceneMenu = "Scene Menu Principale"; //le string de sceneMenu est Scene Menu Principale

    public GameObject imageMiniMap; //pointe vers l'interface de la mini-map
    public GameObject pauseMenu; //pointe vers l'interface du pause menu
    public GameObject levelPlayer; //pointe vers l'interface du niveau du joueur
    public GameObject followQuestWindow; //pointe vers l'interface de la quest
    public GameObject keysWindow; //pointe vers l'interface des touches

    public PlayerQuest playerQuest; //pointe vers le playerQuest

    public Text txtOnQuestTitle; //reference au text pour la quest title
    public Text txtOnQuestDesc; //reference au text pour la quest description
    public Text txtOnQuestGoldReward; //reference au text pour le gold reward
    public Text txtOnQuestExpReward; //reference au text pour le exp reward
    public Text txtOnQuestGoal; //reference au text pour le goal
    public Text levelText; //reference au text pour le level du joueur
    public Text expNeededText; //reference au text pour le exp pour level up

    //fait par Marie-Lee Potvin
    public static PauseMenu instance = null;
    private GameManager manager; //reference vers le singleton
    

    //fait par Emile Deslaueriers
    void Start()
    {
        playerQuest = GameObject.Find("--PlayerQuestManager--").GetComponent<PlayerQuest>(); //touve le GameObject nommé --PlayerQuestManager--

        pauseMenu.gameObject.SetActive(false);
        imageMiniMap.gameObject.SetActive(false);
        levelPlayer.gameObject.SetActive(false);
        followQuestWindow.gameObject.SetActive(false);
        keysWindow.gameObject.SetActive(false);

        manager = GameManager.instance; //cache le GameManager

        Time.timeScale = 1; //le timeScale du jeu reprend
    }

    public void OnMiniMap() //fonction pour voir la mini-map
    {
        imageMiniMap.gameObject.SetActive(true);
    }

    public void OnMiniMapClose() //fonction pour fermer la mini-map
    {
        imageMiniMap.gameObject.SetActive(false);
    }

    //Fait par Marie-Lee Potvin
    public void OnLevelPlayer()
    {
        levelPlayer.gameObject.SetActive(true);
 
        levelText.text = "Level " + PlayerGoldExpLvl.lvlPlayer;
        expNeededText.text = PlayerGoldExpLvl.expNeeded + " exp";
    }

    //Fait par Marie-Lee Potvin
    public void OnLevelPlayerClose()
    {
        levelPlayer.gameObject.SetActive(false);

    }

    //fait par Emile Deslauriers
    public void OnPause() //fonction pour voir les options
    {
        pauseMenu.gameObject.SetActive(true);
        
        Time.timeScale = 0; //le timeScale du jeu est en pause
    }

    public void OnResume() //fonction pour fermer les option et reprendre le jeu
    {
        pauseMenu.gameObject.SetActive(false);

        Time.timeScale = 1; //le timeScale du jeu reprend
    }

    public void OnOpenKeys() //fonction pour voir les options de touche
    {
        keysWindow.gameObject.SetActive(true);
    }

    public void OnCloseKeys() //fonction pour fermer les options de touche
    {
        keysWindow.gameObject.SetActive(false);
    }

    public void OnFollowQuest() //fonction pour voir la current quest
    {
        followQuestWindow.gameObject.SetActive(true);

        txtOnQuestTitle.text = playerQuest.quest.questTitle; //txt pour le nom de la quest
        txtOnQuestDesc.text = playerQuest.quest.questDescription; //txt pour la description de la quest
        txtOnQuestGoldReward.text = playerQuest.quest.goldReward.ToString(); //txt pour le reward en gold de la quest
        txtOnQuestExpReward.text = playerQuest.quest.expReward.ToString(); //txt pour le reward en exp de la quest
        txtOnQuestGoal.text = "Goal: " + playerQuest.quest.goal.currentAmount.ToString() + " / " + playerQuest.quest.goal.requiredAmount.ToString(); //txt pour le goal de la quest
    }

    public void OnCancelQuest() //fonction pour enlever la current quest
    {
        playerQuest.quest.goal.currentAmount = 0; //remet le goal du quest a 0
        playerQuest.quest.isActive = false; //remet la quest active a false

        followQuestWindow.gameObject.SetActive(false);
    }

    public void OnExitFollowQuest() //fonction pour fermer la current quest
    {
        followQuestWindow.gameObject.SetActive(false);
    }

    public void MainMenu() //fonction pour aller au Main Menu
    {
        SceneManager.LoadScene(sceneMenu); //Load la scene principale
    }

    public void ExitGame() //fonction pour fermer le jeu
    {
        Application.Quit(); //Quit l'application
    }

    public void NoQuest() //fonction pour montrer aucune quest suivit
    {
        if(playerQuest.quest.isActive == false) //si aucune quest est active
        {
            txtOnQuestTitle.text = "Following No Quest"; //txt titre de la quest
            txtOnQuestDesc.text = " "; //txt description de la quest
            txtOnQuestGoldReward.text = "X"; //txt gold reward de la quest
            txtOnQuestExpReward.text = "X"; //txt exp reward de la quest
            txtOnQuestGoal.text = "Goal: X"; //txt goal de la quest
        }
    }

    void Update()
    {
        NoQuest(); //appel la fonction no quest

        if (playerQuest.quest.isActive == true) //si il y a une quest active
        {
            //update le quest goal
            txtOnQuestGoal.text = "Goal: " + playerQuest.quest.goal.currentAmount.ToString() + " / " + playerQuest.quest.goal.requiredAmount.ToString();
        }
    }
}
