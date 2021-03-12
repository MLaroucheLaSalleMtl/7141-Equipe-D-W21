using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory:MonoBehaviour
{
    public GameObject[] inventory = new GameObject[9];
    public Button[] InventoryButtons = new Button[9];

    

    public void AddItem(GameObject item)
    {
        bool addedItem = false;

        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory [i]== null)
            {
                inventory [i]= item;
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + " was added");
                addedItem = true;
                item.SendMessage("DoInteraction");
                break;
            }
        }


        if (!addedItem)
        {
            Debug.Log("Inventory if full! Item not added.");
        }
    }

    public void RemoveItem(GameObject item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                inventory[i] = null;
                Debug.Log(item.name + " was removed");
                InventoryButtons[i].image.overrideSprite = null;
                break;
            }
        }
        
    }

    
    void Start()
    {
       
       
    }

     void Update()
    {
     
        
    }



}

