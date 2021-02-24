using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        Debug.Log(levelSystem.GetLvlNumber());
        levelSystem.AddExp(50);
        Debug.Log(levelSystem.GetLvlNumber());
        levelSystem.AddExp(60);
        Debug.Log(levelSystem.GetLvlNumber());
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
