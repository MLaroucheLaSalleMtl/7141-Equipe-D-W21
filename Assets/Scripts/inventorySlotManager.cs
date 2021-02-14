using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventorySlotManager : MonoBehaviour
{

    public Item item;


    public void updateInfo()
    {
        Text displayText = transform.Find("Text").GetComponent<Text>();
        Image displayImage = transform.Find("Image").GetComponent<Image>();

        if (item)
        {
            displayText.text = item.itemName;
            displayImage.sprite = item.icon;
            displayImage.color = Color.white;
        }
        else
        {
            displayText.text = "";
            displayImage.sprite = null;
            displayImage.color = Color.clear;
        }

    }

    public void Use()
    {
        if (item)
        {
            item.Use();
        }
    }
    // Start is called before the first frame update
 private void Start()
    {
        updateInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
