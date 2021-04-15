using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce script sert a gerer les goals des quest avec des enums pour es types de quest 
/// Incrementer la valeur de current goal et avoir des differentes types de quest
/// Script fait par Emile Deslauriers
/// Source : Brackeys, Youtube, QUESTING SYSTEM in Unity!, 10 fev. 2019, 11:05 min
/// Lien youtube : https://www.youtube.com/watch?v=e7VEe_qW4oE&ab_channel=Brackeys
/// </summary>

[System.Serializable] //seriazlized les fields pour etre capable de les changer dans l'inspector
public class QuestGoal
{
    public QuestType questType; //pointe vers le script QuestType
    public int requiredAmount; //variable pour le amount require pour un quest
    public int currentAmount; //variable pour le current amount pour un quest

    public bool IsReached() //bool pour voir si une quest est completer
    {
        //return quand le current amount et plus grand ou egal au required ammount
        return (currentAmount >= requiredAmount);
    }

    public void EnemyDefeated() //fonction pour incrementer le current amount quand un enemie est vaincu
    {
        if(questType == QuestType.Battle) //si le type de quest est egal a Battle
        currentAmount++;
    }
    public void ItemPickUp() //fonction pour incrementer le current amount quand un objet est picked up
    {
        if (questType == QuestType.Gathering) //si le type de quest est egal a Gathering
        currentAmount++;
    }
    public void PickUpMushroom() //fonction pour incrementer le current amount quand un mushroom est picked up
    {
        if (questType == QuestType.GatheringMushroom) //si le type de quest est egal a GatheringMushroom
        currentAmount++;
    }

    public void PickUpApple() //fonction pour incrementer le current amount quand un apple est picked up
    {
        if (questType == QuestType.GatheringApple) //si le type de quest est egal a GatheringApple
            currentAmount++;
    }

    public void PickUpStrawberry() //fonction pour incrementer le current amount quand un strawberry est picked up
    {
        if (questType == QuestType.GatheringStrawberry) //si le type de quest est egal a GatheringStrawberry
            currentAmount++;
    }

    public void PickUpBlueberry() //fonction pour incrementer le current amount quand un blueberry est picked up
    {
        if (questType == QuestType.GatheringBlueberry) //si le type de quest est egal a GatheringBlueberry
            currentAmount++;
    }

    public void PickUpFlower() //fonction pour incrementer le current amount quand une fleur est picked up
    {
        if (questType == QuestType.GatheringFlower) //si le type de quest est egal a GatheringFlower
            currentAmount++;
    }

    public void PickUpTool() //fonction pour incrementer le current amount quand un tool est picked up
    {
        if (questType == QuestType.GatheringTool) //si le type de quest est egal a GatheringTool
            currentAmount++;
    }

    public void PickUpWood() //fonction pour incrementer le current amount quand du wood est picked up
    {
        if (questType == QuestType.GatheringWood) //si le type de quest est egal a GatheringWood
            currentAmount++;
    }

    public void PickUpStone() //fonction pour incrementer le current amount quand du stone est picked up
    {
        if (questType == QuestType.GatheringStone) //si le type de quest est egal a GatheringStone
            currentAmount++;
    }

    public void PickUpMetal() //fonction pour incrementer le current amount quand du metal est picked up
    {
        if (questType == QuestType.GatheringMetal) //si le type de quest est egal a GatheringMetal
            currentAmount++;
    }

    public void GoblinDefeated() //fonction pour incrementer le current amount quand un goblin est vaincu
    {
        if (questType == QuestType.BattleGoblin) //si le type de quest est egal a BattleGoblin
            currentAmount++;
    }

    public void SlimeDefeated() //fonction pour incrementer le current amount quand un slime est vaincu
    {
        if (questType == QuestType.BattleSlime) //si le type de quest est egal a BattleSlime
            currentAmount++;
    }
}

//enumeration pour toute les sortes de quests possible
public enum QuestType { Battle, 
                        Gathering , 
                        GatheringMushroom , 
                        GatheringApple ,
                        GatheringStrawberry ,
                        GatheringBlueberry ,
                        GatheringFlower ,
                        GatheringTool ,
                        GatheringWood ,
                        GatheringStone ,
                        GatheringMetal ,
                        BattleGoblin , 
                        BattleSlime}
