using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce script sert a gerer les quests
/// Script fait par Emile Deslauriers
/// Source : Brackeys, Youtube, QUESTING SYSTEM in Unity!, 10 fev. 2019, 3:50 min
/// Lien youtube : https://www.youtube.com/watch?v=e7VEe_qW4oE&ab_channel=Brackeys
/// </summary>

[System.Serializable] //seriazlized les fields pour etre capable de les changer dans l'inspector
public class Quest
{
    public bool isActive; //variable bool pour determiner si une quest est active

    public string questTitle; //titre de la quest
    public string questDescription; //description de la quest
    public int goldReward; //gold reward de la quest
    public int expReward; //exp reward de la quest

    public QuestGoal goal; //reference au script QuestGoal

    public void Finished() //fonction servant a etre appeller apres avoir fini une quest
    {
        isActive = false; //met la quest active a false
    }
}
