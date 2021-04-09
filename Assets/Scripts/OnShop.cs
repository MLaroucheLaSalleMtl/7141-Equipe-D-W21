using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnShop : MonoBehaviour
{
    public GameObject shopBox;

    public bool shopOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && shopOn)
        {

            if (shopBox.activeInHierarchy)
            {
                shopBox.SetActive(false);
            }
            else
            {
                shopBox.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopOn = false;
            shopBox.SetActive(false);
        }
    }

}
