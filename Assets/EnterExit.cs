using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExit : MonoBehaviour
{
    [SerializeField] private GameObject teleport; //Ou teleporter
    [SerializeField] private GameObject character; //Joueur / Character

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Si triggered par le tag Player alors
        {
            character.transform.position = teleport.transform.position; //Change de position (Character position = Spawning position)
        }
    }
}
