using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce script sert a garder le GameObject --PlayerQuest-- entre les scene
/// Script fait par Emile Deslauriers
/// Source : Unity Documentation, Object.DontDestroyOnLoad, 11 avril 2021
/// Lien : https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html
/// </summary>

public class KeepBetweenScene : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SavePlayer"); //trouve le GameObject avec le tag SavePlayer

        if (objs.Length > 1) //si il y a plus que 1 de ce GameObject
        {
            Destroy(this.gameObject); //detruit le
        }
        DontDestroyOnLoad(this.gameObject); //ne pas detruire ce GameObject
    }
}
