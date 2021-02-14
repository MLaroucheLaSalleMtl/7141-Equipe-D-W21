using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST} //state du combat
public class BattleManager : MonoBehaviour
{
    public GameObject playerCharacter; //point vers les stats prefab du joueur 
    public GameObject enemyCharacter; //point vers les stats prefab de l'enemy

    public Transform playerSpawn; //point vers la position du GameObjet playerSpawn
    public Transform enemySpawn; //point vers la position du GameObjet enemySpawn

    Stat playerStat;
    Stat enemyStat;

    public Text combatText;

    public BattleHUD playerHUD; //point vers le playerHUD
    public BattleHUD enemyHUD; //point vers le enemyHUD

    public BattleState state; //point vers les states du combat

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START; //declare que le state == START
        SetupBattle(); //appelle la fonction SetupBattle
    }

    void SetupBattle() //fonction qui va principalement importer les stats prefab du joueur et de l'enemy
    {
        GameObject playerGameObject = Instantiate(playerCharacter, playerSpawn); //viens importer les stats prefab du joueur
        playerStat = playerGameObject.GetComponent<Stat>(); //reference script Stat du player

        GameObject enemyGameObject = Instantiate(enemyCharacter, enemySpawn); //viens importer les stats prefab du enemy
        enemyStat = enemyGameObject.GetComponent<Stat>(); //reference script Stat du enemy

        combatText.text = enemyStat.characterName + " Is Ready To Battle!!!"; //ecrit le nom dans combatText

        playerHUD.SetHUD(playerStat); //appelle la fonction SetHUD pour changer le playerHUD avec les stats du player
        enemyHUD.SetHUD(enemyStat); //appelle la fonction SetHUD pour changer le enemyHUD avec les stats du enemy
    }
}
