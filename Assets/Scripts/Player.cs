using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Level level;
    public static int doWeAddXp = 0;
    public static Player instance = null; //singleton
    private BattleManager battleManager; //reference vers le singleton

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //Level.currentLevel = 1;
        level = new Level(1, OnLevelUp);
        //battleManager = BattleManager.instance; //cache le battlemanager
    }

    public void OnLevelUp()
    {
        print("Level up!");
    }

    // Update is called once per frame
    void Update()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.X))
        {
            level.AddXp(40);
            //Level.AddXp(40);
        }

        //if (battleManager.doWeAddXp == 1)
        if (doWeAddXp == 1) //doWeAddXp = 0, change pour devenir 1 après avoir gagné un combat (battleManager)
        {
            level.AddXp(40);
            //Level.AddXp(40);
            doWeAddXp = 0; //on remet la variable à 0 après avoir gagné du Xp
            //battleManager.doWeAddXp = 0;
        }
    }
}
