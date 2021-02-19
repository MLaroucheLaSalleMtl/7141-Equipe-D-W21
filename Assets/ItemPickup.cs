using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(other.gameObject);
        }
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
