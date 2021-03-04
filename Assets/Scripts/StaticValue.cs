using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticValue : MonoBehaviour
{
   static public float value = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value += (Time.deltaTime * 1.5f);
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(value);
        }
    }
}
