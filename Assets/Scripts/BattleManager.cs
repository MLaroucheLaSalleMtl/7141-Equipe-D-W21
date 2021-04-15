using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Ce script sert a gerer le Battle System du jeu
/// Script fait par Emile Deslauriers avec quelque partie fait par Marie-Lee Potvin
/// Source : Brackeys, Youtube, Turn-Based Combat in Unity, 24 nov. 2019
/// Lien youtube : https://www.youtube.com/watch?v=_1pz_ohupPs&ab_channel=Brackeys
/// </summary>

//Parti fait par Emile Deslauriers
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST} //enum pour le state du combat

public class BattleManager : MonoBehaviour
{
    public GameObject blankImage; //pointe vers une image blank
    public GameObject playerCharacter; //pointe vers les stats prefab du joueur 
    public GameObject enemyCharacter; //pointe vers les stats prefab de l'enemy

    public Transform playerSpawn; //pointe vers la position du GameObjet playerSpawn
    public Transform enemySpawn; //pointe vers la position du GameObjet enemySpawn

    Stat playerStat; //pointe vers le scrtip Stat du player
    Stat enemyStat; //pointe vers le scrtip Stat du enemy

    public Text combatText; //pointe vers la boite de dialogue
    public Text numberHealthPot; //pointe vers le nombre de HealthPot
    public Text numberManaPot; //pointe vers le nombre de ManaPot
    public Text numberFlowerfire; //pointe vers le nombre Flowerfire

    public BattleHUD playerHUD; //pointe vers le playerHUD
    public BattleHUD enemyHUD; //pointe vers le enemyHUD

    public GameObject objectHUD; //pointe vers la fenetre des objets
    public GameObject spellHUD; //pointe vers la fenetre des spells

    public BattleState state; //pointe vers les states du combat

    public PlayerQuest playerQuest; //pointe vers le playerQuest

    // Start is called before the first frame update
    void Start()
    {
        playerQuest = GameObject.Find("--PlayerQuestManager--").GetComponent<PlayerQuest>(); //touve le GameObject nommé --PlayerQuestManager--

        blankImage.gameObject.SetActive(true); //image pour cacher les boutons est afficher
        state = BattleState.START; //declare que le state == START
        StartCoroutine(SetupBattle()); //appelle la fonction SetupBattle et appelle StartCoroutine

        playerStat.characterLevel = PlayerGoldExpLvl.lvlPlayer;
        AddStat();
    }


    //partie fait par Emile Deslauriers
    IEnumerator SetupBattle() //fonction qui va principalement importer les stats prefab du joueur et de l'enemy
                              //IEnumerator est utiliser pour mettre des secondes entre les actions
    {
        GameObject playerGameObject = Instantiate(playerCharacter, playerSpawn); //viens importer les stats prefab du joueur
        playerStat = playerGameObject.GetComponent<Stat>(); //reference script Stat du player

        GameObject enemyGameObject = Instantiate(enemyCharacter, enemySpawn); //viens importer les stats prefab du enemy
        enemyStat = enemyGameObject.GetComponent<Stat>(); //reference script Stat du enemy

        combatText.text = enemyStat.characterName + " Is Ready To Battle!!!"; //ecrit le nom dans combatText Is Ready To Battle!!!

        playerHUD.SetHUD(playerStat); //appelle la fonction SetHUD pour changer le playerHUD avec les stats du player
        enemyHUD.SetHUD(enemyStat); //appelle la fonction SetHUD pour changer le enemyHUD avec les stats du enemy

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        state = BattleState.PLAYERTURN; //le state est definie par le tour du joueur maintenant
        PlayerTurn(); //appelle la fonction PlayerTurn 
    }

    void PlayerTurn() //fonction pour les actions du joueur pendant sont tour
    {
        blankImage.gameObject.SetActive(false); //image pour cacher les boutons est invisible
        combatText.text = "Pick an action?"; //afficher Pick an action dans la zone texte de combats
        numberHealthPot.text = "x" + Inventory.healthPotion; //change le txt du nombre de healthPotion 
        numberManaPot.text = "x" + Inventory.manaPotion; //change le txt du nombre de manaPotion
        numberFlowerfire.text = "x" + Inventory.fireFlower; //change le txt du nombre de fireFlower

        playerHUD.SetHUD(playerStat); //change le HUD a partir du PlayerStat
        enemyHUD.SetHUD(enemyStat); //change le HUD a partir du EnemyStat
    }

    IEnumerator PlayerAttack() //fonction pour les attack normal du player
    {
        blankImage.gameObject.SetActive(true); //blank image est visible
        bool isDead = enemyStat.TakeDamage(playerStat.basicDamage); //fait du degat a l'enemy et check si il est mort
        enemyHUD.SetHP(enemyStat.currentHp); //update le hp du enemy
        enemyHUD.SetHUD(enemyStat); //update le HUD de l'enemie

        combatText.text = "You Attacked For " + playerStat.basicDamage + " DMG!"; //affiche le nombre de point d'attack

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        if (isDead) //si l'enemy est mort
        {
            state = BattleState.WON; //state devient WON
            StartCoroutine(ExitBattle()); //appelle la fonction ExitBattle
        }
        else //sinon
        {
            state = BattleState.ENEMYTURN; //state devient ENEMYTURN
            StartCoroutine(EnemyTurn()); //appelle la fonction ENEMYTURN
        }
    }

    IEnumerator PlayerHealthPotion() //fonction pour le heal du player
    {
        blankImage.gameObject.SetActive(true);//blank image est visible
        playerStat.OnHeal(playerStat.healthPotionPoints); //appelle la fonction heal dans le script stat

        objectHUD.gameObject.SetActive(false); //desactive la fenetre des objets
        playerHUD.SetHP(playerStat.currentHp); //update le hp du joueur
        playerHUD.SetHUD(playerStat); //update le HUD du player

        combatText.text = "You Healed For " + playerStat.healthPotionPoints + " HP!"; //affiche le nombre de vie ajouter

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        state = BattleState.ENEMYTURN; //le state est rendu ENEMYTURN
        StartCoroutine(EnemyTurn()); //appelle la fonction EnemyTurn
    }

    IEnumerator PlayerManaPotion() //fonction pour le mana du player
    {
        blankImage.gameObject.SetActive(true); //blank image est visible
        playerStat.OnMana(playerStat.manaPotionPoints); //appelle la fonction mana dans le script stat

        objectHUD.gameObject.SetActive(false); //desactive la fenetre des objets
        playerHUD.SetMana(playerStat.currentMana); //update le hp du joueur
        playerHUD.SetHUD(playerStat); //update le HUD du player
        combatText.text = "You Mana UP For " + playerStat.manaPotionPoints + " Mana!"; //affiche le nombre de vie ajouter

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        state = BattleState.ENEMYTURN; //le state est rendu ENEMYTURN
        StartCoroutine(EnemyTurn()); //appelle la fonction EnemyTurn
    }

    IEnumerator PlayerFireFlower() //fonction appeller quand l'objet Fire Flower est utiliser
    {
        blankImage.gameObject.SetActive(true); //blank image est visible
        bool isDead = enemyStat.TakeDamage(playerStat.fireFlowerDamage); //si le damage de flower fire tue l'enemi

        objectHUD.gameObject.SetActive(false); //la fenetre d'objet est desactiver
        enemyHUD.SetHP(enemyStat.currentHp); //update le HP de l'enemie
        enemyHUD.SetHUD(enemyStat); //update le HUD du enemy

        combatText.text = "Your Object Did " + playerStat.fireFlowerDamage + " DMG!"; //affiche le nombre de point d'attack

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        if (isDead) //si l'enemy est mort
        {
            state = BattleState.WON; //state devient WON
            StartCoroutine(ExitBattle()); //appelle la fonction ExitBattle
        }
        else //sinon
        {
            state = BattleState.ENEMYTURN; //state devient ENEMYTURN
            StartCoroutine(EnemyTurn()); //appelle la fonction ENEMYTURN
        }
    }

    IEnumerator PlayerVenemousSpit() //fonction appeller quand le spell Venemous spit est utiliser
        
    {
        blankImage.gameObject.SetActive(true); //blank image est afficher
        bool isDead = enemyStat.TakeDamage(playerStat.spellVenemousSpitDmg); //fait du degat a l'enemy et check si il est mort

        spellHUD.gameObject.SetActive(false); //spell window est invicible
        playerStat.currentMana -= playerStat.spellVenemousSpitMana; //current mana moins la mana pour Venemous Spit
        enemyHUD.SetHP(enemyStat.currentHp); //update le hp du enemy
        enemyHUD.SetHUD(enemyStat); //update le HUD de l'enemie
        playerHUD.SetMana(playerStat.currentMana); //update le hp du enemy
        playerHUD.SetHUD(playerStat); //update le HUD du player

        combatText.text = "Venemous Spit Did " + playerStat.spellVenemousSpitDmg + " DMG!"; //affiche le nombre de point d'attack

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        if (isDead) //si l'enemy est mort
        {
            state = BattleState.WON; //state devient WON
            StartCoroutine(ExitBattle()); //appelle la fonction ExitBattle
        }
        else //sinon
        {
            state = BattleState.ENEMYTURN; //state devient ENEMYTURN
            StartCoroutine(EnemyTurn()); //appelle la fonction ENEMYTURN
        }
    }

    IEnumerator PlayerWaterball() //fonction appeller quand le spell Water Ball est utiliser
    {
        blankImage.gameObject.SetActive(true); //blank image est afficher
        bool isDead = enemyStat.TakeDamage(playerStat.spellWaterballDmg); //fait du degat a l'enemy et check si il est mort

        spellHUD.gameObject.SetActive(false); //l'interface des spells est invicible
        playerStat.currentMana -= playerStat.spellWaterballMana; //current mana moins la mana pour Water Ball
        enemyHUD.SetHP(enemyStat.currentHp); //update le hp du enemy
        enemyHUD.SetHUD(enemyStat); //update le HUD du joueur
        playerHUD.SetMana(playerStat.currentMana); //update le hp du enemy
        playerHUD.SetHUD(playerStat); //update le HUD de l'enemy

        combatText.text = "Waterball Did " + playerStat.spellWaterballDmg + " DMG!"; //affiche le nombre de point d'attack

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        if (isDead) //si l'enemy est mort
        {
            state = BattleState.WON; //state devient WON
            StartCoroutine(ExitBattle()); //appelle la fonction ExitBattle
        }
        else //sinon
        {
            state = BattleState.ENEMYTURN; //state devient ENEMYTURN
            StartCoroutine(EnemyTurn()); //appelle la fonction ENEMYTURN
        }
    }

    IEnumerator PlayerMudThrow() //fonction appeller quand le spell Mud Throw est utiliser
    {
        blankImage.gameObject.SetActive(true); //la blankImage est active
        bool isDead = enemyStat.TakeDamage(playerStat.spellMudThrowDmg); //fait du degat a l'enemy et check si il est mort

        spellHUD.gameObject.SetActive(false); //le HUD des spells n'est plus active
        playerStat.currentMana -= playerStat.spellMudThrowMana; //current mana moins la mana pour Mud Throw
        enemyHUD.SetHP(enemyStat.currentHp); //update le hp du enemy
        enemyHUD.SetHUD(enemyStat); //update le HUD du enemie
        playerHUD.SetMana(playerStat.currentMana); //update le hp du enemy
        playerHUD.SetHUD(playerStat); //update le HUD du player

        combatText.text = "MudThrow Did " + playerStat.spellMudThrowDmg + " DMG!"; //affiche le nombre de point d'attack

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        if (isDead) //si l'enemy est mort
        {
            state = BattleState.WON; //state devient WON
            StartCoroutine(ExitBattle()); //appelle la fonction ExitBattle
        }
        else //sinon
        {
            state = BattleState.ENEMYTURN; //state devient ENEMYTURN
            StartCoroutine(EnemyTurn()); //appelle la fonction ENEMYTURN
        }
    }

    IEnumerator EnemyTurn() //fonction pour le tour du enemie
    {
        blankImage.gameObject.SetActive(true); //le blank image pour cacher les boutons est visible
        combatText.text = enemyStat.characterName + " Is Attacking!"; //affiche dans le dialogue le nom de l'enemy Is Atacking!
        numberHealthPot.text = "x" + Inventory.healthPotion; //change le txt du nombre de healthPotion
        numberManaPot.text = "x" + Inventory.manaPotion; //change le txt du nombre de manaPotion
        numberFlowerfire.text = "x" + Inventory.fireFlower; //change le txt du nombre de fireFlower

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        bool isDead = playerStat.TakeDamage(enemyStat.basicDamage); //fait du degat au joueur et check si il est mort 
        playerHUD.SetHP(playerStat.currentHp); //update le hp du joueur
        playerHUD.SetHUD(playerStat); //update le HUD du playerStat 
        combatText.text = "He Attack You For " + enemyStat.basicDamage + " DMG!";

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        if(isDead) //si le player mort apres une attack
        {
            state = BattleState.LOST; //le state du battle devient LOST pour avoir perdu le combat
            StartCoroutine(ExitBattle()); //appelle la fonction ExitBattle pour quitter le combat
        }
        else //sinon
        {
            state = BattleState.PLAYERTURN; //le state du battle devient PLAYERTURN pour el tour du joueur
            PlayerTurn(); //appelle la fonction PlayerTurn pour le tour du joueur
        }
    }

    IEnumerator ExitBattle() //fonction pour quitter le combat
    {
        if (state == BattleState.WON) //si le combat est gagné
        {
            //Parti fait par Marie-Lee Potvin
            if (textEvilBoss.oldManCombatBegin == 1) //le texte du old man s'est affiché et c'est bien lui qu'on combat
            {
                GameManager.oldManDead = 1; //on met la valeur 1 pour qu'on sache qu'il faut afficher le panel endGame
            }
            AddExp(); //on a gagné le combat, alors on ajoute des points d'expérience au joueur

            //Parti fait par Emile Deslauriers
            combatText.text = "You've Defeated Your Enemy!"; //affiche dans le dialogue You've Defeated Your Enemy!
            yield return new WaitForSeconds(2f); //attendre 2 secondes
            Scene scene = SceneManager.GetActiveScene(); //recois le nom de la scene
            playerQuest.BattleQuestWon(); //appel la fonction BattleQuestWon du script PlayerQuest

            if (scene.name == "Scene Combat Goblin") //si la scene name est Scene Combat Goblin
            {
                playerQuest.BattleGoblinWon(); //appel la fonction BattleGoblinWon du script PlayerQuest
            }

            //si la scene name est une scene de Slime
            if (scene.name == "Scene Combat SlimeBlue" ||
                scene.name == "Scene Combat SlimeRed" ||
                scene.name == "Scene Combat SlimeYellow" ||
                scene.name == "Scene Combat SlimeSpecial")
            {
                playerQuest.BattleSlimeWon(); //appel la fonction BattleSlimeWon du script PlayerQuest
            }
            SceneManager.LoadScene("Scene Principale"); //change de scene pour la scene principale
        }
        else if (state == BattleState.LOST) //si le combat est perdu
        {
            combatText.text = "You've Lost The Battle!"; //affiche dans le dialogue You've Lost The Battle!

            yield return new WaitForSeconds(2f); //attendre 2 secondes

            SceneManager.LoadScene("Scene Principale"); //change de scene pour la scene principale
        }
    }

    void Flee() //fonction flee le combat
    {
        SceneManager.LoadScene("Scene Principale"); //load la scene principale
    }

    public void OnAttackClick() //fonction pour le bouton d'Attaque
    {
        if (state != BattleState.PLAYERTURN) //si ce n'est pas le tour du joueur
        { 
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerAttack()); //appelle la fonction PlayerAttack
    }

    public void OnHealthPotionClick() //fonction pour l'objet Health Potion
    {
        if (state != BattleState.PLAYERTURN || Inventory.healthPotion <= 0) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerHealthPotion()); //appelle la fonction PlayerHealthPotion
    }

    public void OnManaPotionClick() //fonction pour l'objet Mana Potion
    {
        if (state != BattleState.PLAYERTURN || Inventory.manaPotion <= 0) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerManaPotion()); //appelle la fonction PlayerHealthPotion
    }

    public void OnFireFlowerClick() //fonction pour l'objet Fire Flower
    {
        if (state != BattleState.PLAYERTURN || Inventory.fireFlower <= 0) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerFireFlower());
        Inventory.fireFlower -= 1; //reduit le nombre de fireFlower dans l'inventaire
    }

    public void OnVenemousSpit() //fonction pour le spell Venemous Spit
    {
        if (state != BattleState.PLAYERTURN || playerStat.spellVenemousSpitMana > playerStat.currentMana) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerVenemousSpit()); //appelle la fonction PlayerVenemousSpit
    }

    public void OnWaterball() //fonction pour le spell Water Ball
    {
        if (state != BattleState.PLAYERTURN || playerStat.spellWaterballMana > playerStat.currentMana) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerWaterball()); //appelle la fonction PLayerWaterball
    }

    public void OnMudThrow() //fonction pour le spell Mud Throw
    {
        if (state != BattleState.PLAYERTURN || playerStat.spellMudThrowMana > playerStat.currentMana) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }
        StartCoroutine(PlayerMudThrow()); //appelle la fonction PLayerMudThrow
    }

    public void OnFleeClick()
    {
        if (state != BattleState.PLAYERTURN) //si le state n'est pas PlayerTurn
        {
            return; //return rien
        }
        Flee(); //appelle la fonction Flee
    }

    //fonction créer par Marie-Lee Potvin
    public void AddExp() 
    {
        PlayerGoldExpLvl.expOwned += 300;
    }

    //fonction créer par Marie-Lee Potvin
    public void AddStat()
    {
        //On regarde le niveau du joueur et cela va influencer les stats pour les attaques, maxHp et maxMana
        playerStat.basicDamage += (int)(playerStat.basicDamage * 0.1 * PlayerGoldExpLvl.lvlPlayer);
        playerStat.spellMudThrowDmg += (int)(playerStat.spellMudThrowDmg * 0.1 * PlayerGoldExpLvl.lvlPlayer);
        playerStat.spellVenemousSpitDmg += (int)(playerStat.spellVenemousSpitDmg * 0.1 * PlayerGoldExpLvl.lvlPlayer);
        playerStat.spellWaterballDmg += (int)(playerStat.spellWaterballDmg * 0.1 * PlayerGoldExpLvl.lvlPlayer);
        playerStat.maxHp += (int)(playerStat.maxHp * 0.01 * PlayerGoldExpLvl.lvlPlayer);
        playerStat.currentHp += (int)(playerStat.currentHp * 0.01 * PlayerGoldExpLvl.lvlPlayer);
        playerStat.maxMana += (int)(playerStat.maxMana * 0.01 * PlayerGoldExpLvl.lvlPlayer);
        playerStat.currentMana += (int)(playerStat.currentMana * 0.01 * PlayerGoldExpLvl.lvlPlayer);
    }
}