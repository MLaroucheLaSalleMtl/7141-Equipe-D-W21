using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLvlUp : MonoBehaviour
{
    public LevelSystem level;

    // Start is called before the first frame update
    void Start()
    {
        level = new LevelSystem(1, OnLvlUp);
    }

    public void OnLvlUp()
    {
        print("I level up!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
