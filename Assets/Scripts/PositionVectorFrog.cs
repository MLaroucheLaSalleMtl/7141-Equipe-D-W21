using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
//public class PositionVectorFrog : MonoBehaviour
public class PositionVectorFrog : ScriptableObject
{
    public Vector2 initialValue;
    //public GameObject frog;

    // Start is called before the first frame update
    void Start()
    {
        //float posX = frog.transform.position.x;
        //float posY = frog.transform.position.y;
    }

    public void FrogPos()
    {
        //PlayerPrefs.SetFloat("p_x", frog.transform.position.x);
        //PlayerPrefs.SetFloat("p_y", frog.transform.position.y);
    }
   
      

    // Update is called once per frame
    void Update()
    {
        
    }
}
