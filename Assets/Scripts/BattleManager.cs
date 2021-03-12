using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST} //state du combat

public class BattleManager : MonoBehaviour
{
    public GameObject blankImage;
    public GameObject playerCharacter; //point vers les stats prefab du joueur 
    public GameObject enemyCharacter; //point vers les stats prefab de l'enemy

    public Transform playerSpawn; //point vers la position du GameObjet playerSpawn
    public Transform enemySpawn; //point vers la position du GameObjet enemySpawn

    Stat playerStat; //point vers le scrtip Stat du player
    Stat enemyStat; //point vers le scrtip Stat du enemy

    public Text combatText; //point vers la boite de dialogue
    public Text numberHealthPot;
    public Text numberManaPot;

    public BattleHUD playerHUD; //point vers le playerHUD
    public BattleHUD enemyHUD; //point vers le enemyHUD

    public GameObject objectHUD; //point vers la fenetre des objets
    public GameObject spellHUD; //pointe vers la fenetre des spells

    public BattleState state; //point vers les states du combat

    // Start is called before the first frame update
    void Start()
    {
        blankImage.gameObject.SetActive(true);
        state = BattleState.START; //declare que le state == START
        StartCoroutine(SetupBattle()); //appelle la fonction SetupBattle et appelle StartCoroutine
    }

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
        blankImage.gameObject.SetActive(false);
        combatText.text = "Pick an action?"; //afficher Pick an action dans la zone texte de combats
        numberHealthPot.text = "x" + playerStat.nbHealthPot;
        numberManaPot.text = "x" + playerStat.nbManaPot;
        playerHUD.SetHUD(playerStat);
        enemyHUD.SetHUD(enemyStat);
    }

    IEnumerator PlayerAttack() //fonction pour les attack normal du player
    {
        blankImage.gameObject.SetActive(true);
        bool isDead = enemyStat.TakeDamage(playerStat.basicDamage); //fait du degat a l'enemy et check si il est mort
        enemyHUD.SetHP(enemyStat.currentHp); //update le hp du enemy
        enemyHUD.SetHUD(enemyStat);

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

    IEnumerator PlayerHealthPotion() //fonction pour les heal du player
    {
        blankImage.gameObject.SetActive(true);
        playerStat.OnHeal(playerStat.healthPotionPoints); //appelle la fonction heal dans le script stat

        objectHUD.gameObject.SetActive(false); //desactive la fenetre des objets
        playerHUD.SetHP(playerStat.currentHp); //update le hp du joueur
        playerHUD.SetHUD(playerStat);

        combatText.text = "You Healed For " + playerStat.healthPotionPoints + " HP!"; //affiche le nombre de vie ajouter

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        state = BattleState.ENEMYTURN; //le state est rendu ENEMYTURN
        StartCoroutine(EnemyTurn()); //appelle la fonction EnemyTurn
    }

    IEnumerator PlayerManaPotion() //*Change*
    {
        blankImage.gameObject.SetActive(true);
        playerStat.OnMana(playerStat.manaPotionPoints);

        objectHUD.gameObject.SetActive(false); //desactive la fenetre des objets
        playerHUD.SetMana(playerStat.currentMana); //update le hp du joueur
        playerHUD.SetHUD(playerStat);
        combatText.text = "You Mana UP For " + playerStat.manaPotionPoints + " Mana!"; //affiche le nombre de vie ajouter

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        state = BattleState.ENEMYTURN; //le state est rendu ENEMYTURN
        StartCoroutine(EnemyTurn()); //appelle la fonction EnemyTurn
    }

    IEnumerator PlayerFireFlower() //*CHANGE*
    {
        blankImage.gameObject.SetActive(true);
        bool isDead = enemyStat.TakeDamage(playerStat.fireFlowerDamage);

        objectHUD.gameObject.SetActive(false);
        enemyHUD.SetHP(enemyStat.currentHp);
        enemyHUD.SetHUD(enemyStat);

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

    IEnumerator PlayerVenemousSpit() //*Change*
    {
        blankImage.gameObject.SetActive(true);
        bool isDead = enemyStat.TakeDamage(playerStat.spellVenemousSpitDmg); //fait du degat a l'enemy et check si il est mort

        spellHUD.gameObject.SetActive(false);
        playerStat.currentMana -= playerStat.spellVenemousSpitMana;
        enemyHUD.SetHP(enemyStat.currentHp); //update le hp du enemy
        enemyHUD.SetHUD(enemyStat);
        playerHUD.SetMana(playerStat.currentMana); //update le hp du enemy
        playerHUD.SetHUD(playerStat);

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

    IEnumerator PlayerWaterball() 
    {
        blankImage.gameObject.SetActive(true);
        bool isDead = enemyStat.TakeDamage(playerStat.spellWaterballDmg); //fait du degat a l'enemy et check si il est mort

        spellHUD.gameObject.SetActive(false);
        playerStat.currentMana -= playerStat.spellWaterballMana;
        enemyHUD.SetHP(enemyStat.currentHp); //update le hp du enemy
        enemyHUD.SetHUD(enemyStat);
        playerHUD.SetMana(playerStat.currentMana); //update le hp du enemy
        playerHUD.SetHUD(playerStat);

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

    IEnumerator PlayerMudThrow()
    {
        blankImage.gameObject.SetActive(true);
        bool isDead = enemyStat.TakeDamage(playerStat.spellMudThrowDmg); //fait du degat a l'enemy et check si il est mort

        spellHUD.gameObject.SetActive(false);
        playerStat.currentMana -= playerStat.spellMudThrowMana;
        enemyHUD.SetHP(enemyStat.currentHp); //update le hp du enemy
        enemyHUD.SetHUD(enemyStat);
        playerHUD.SetMana(playerStat.currentMana); //update le hp du enemy
        playerHUD.SetHUD(playerStat);

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

    IEnumerator EnemyTurn() //fonction pour le tour du enemy
    {
        blankImage.gameObject.SetActive(true);  
        combatText.text = enemyStat.characterName + " Is Attacking!"; //affiche dans le dialogue le nom de l'enemy Is Atacking!
        numberHealthPot.text = "x" + playerStat.nbHealthPot;
        numberManaPot.text = "x" + playerStat.nbManaPot;

        yield return new WaitForSeconds(2f); //attendre 2 secondes

        bool isDead = playerStat.TakeDamage(enemyStat.basicDamage); //fait du degat au joueur et check si il est mort 
        playerHUD.SetHP(playerStat.currentHp); //update le hp du joueur
        playerHUD.SetHUD(playerStat);
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
            combatText.text = "You've Defeated Your Enemy!"; //affiche dans le dialogue You've Defeated Your Enemy!

            yield return new WaitForSeconds(2f); //attendre 2 secondes

            SceneManager.LoadScene("Scene Principale"); //change de scene pour la scene principale
        }
        else if (state == BattleState.LOST) //si le combat est perdu
        {
            combatText.text = "You've Lost The Battle!"; //affiche dans le dialogue You've Lost The Battle!

            yield return new WaitForSeconds(2f); //attendre 2 secondes

            SceneManager.LoadScene("Scene Principale"); //change de scene pour la scene principale
        }
    }

    void Flee()
    {
        SceneManager.LoadScene("Scene Principale");
    }

    public void OnAttackClick() //action du button attack
    {
        if (state != BattleState.PLAYERTURN) //si ce n'est pas le tour du joueur
        { 
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerAttack()); //appelle la fonction PlayerAttack
    }

    public void OnHealthPotionClick() //action du button heal
    {
        if (state != BattleState.PLAYERTURN || playerStat.nbHealthPot <= 0) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerHealthPotion()); //appelle la fonction PlayerHealthPotion
    }

    public void OnManaPotionClick() //action du button heal *CHANGE*
    {
        if (state != BattleState.PLAYERTURN || playerStat.nbManaPot <= 0) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerManaPotion()); //appelle la fonction PlayerHealthPotion
    }

    public void OnFireFlowerClick()
    {
        if (state != BattleState.PLAYERTURN) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerFireFlower());
    }

    public void OnVenemousSpit() //*change*
    {
        if (state != BattleState.PLAYERTURN || playerStat.spellVenemousSpitMana > playerStat.currentMana) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerVenemousSpit());
    }

    public void OnWaterball()
    {
        if (state != BattleState.PLAYERTURN || playerStat.spellWaterballMana > playerStat.currentMana) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerWaterball());
    }

    public void OnMudThrow() 
    {
        if (state != BattleState.PLAYERTURN || playerStat.spellMudThrowMana > playerStat.currentMana) //si ce n'est pas le tour du joueur
        {
            return; //retroune rien si le joueur appuye sur le button pendant que ce n'est pas son tour
        }

        StartCoroutine(PlayerMudThrow());
    }

    public void OnFleeClick()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        Flee();
    }
}