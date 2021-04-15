using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ce script sert a gerer la quest suivit du joeur avec les PickUp, les Combats et etre capable de TurnIn
/// Script fait par Emile Deslauriers
/// </summary>

public class PlayerQuest : MonoBehaviour
{
    public Quest quest; //reference au script Quest

    public void ItemQuestPickUp() //fonction pour appeller une fonction dans le script goal si il a une quest d'active
    {
        if (quest.isActive)
        {
            quest.goal.ItemPickUp();
        }
    }

    public void MushroomPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpMushroom();
        }
    }

    public void StrawberryPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpStrawberry();
        }
    }

    public void ApplePickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpApple();
        }
    }

    public void BlueberryPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpBlueberry();
        }
    }

    public void FlowerPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpFlower();
        }
    }

    public void ToolPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpTool();
        }
    }

    public void WoodPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpWood();
        }
    }

    public void StonePickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpStone();
        }
    }

    public void MetalPickUp()
    {
        if (quest.isActive)
        {
            quest.goal.PickUpMetal();
        }
    }

    public void BattleQuestWon()
    {
        if (quest.isActive)
        {
            quest.goal.EnemyDefeated();
        }
    }

    public void BattleGoblinWon()
    {
        if (quest.isActive)
        {
            quest.goal.GoblinDefeated();
        }
    }

    public void BattleSlimeWon()
    {
        if (quest.isActive)
        {
            quest.goal.SlimeDefeated();
        }
    }

    public void TurnInQuest() //fonction pour turn in un quest apres l'avoir completer
    {
        if (quest.isActive) //si la quest est active
        {
            if (quest.goal.IsReached()) //si le goal est reached
            {
                PlayerGoldExpLvl.goldOwned += quest.goldReward; //increment le gold du joueur selon le gold reward de la quest completer
                PlayerGoldExpLvl.expOwned += quest.expReward; //increment le gold du joueur selon le exp reward de la quest completer
                quest.goal.currentAmount = 0; //remet le current goal amount a 0
                quest.Finished(); //appel la fonction Finished du script Quest
            }
        }
    }
}
