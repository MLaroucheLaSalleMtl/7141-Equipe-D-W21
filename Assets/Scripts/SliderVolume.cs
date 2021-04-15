using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Ce script sert change le niveau du volume
/// Script fait par Emile Deslauriers
/// </summary>

[RequireComponent(typeof(Slider))] //trouve le component slider
public class SliderVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioM = null;  //audioM AudioMixer initialiser a NULL
    [SerializeField] private string nameParam = null; //nameParam string initialiser a NULL
    private Slider slider; //point vers le slider

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>(); //recois le component slider

        float v = PlayerPrefs.GetFloat(nameParam, 0); //recois le player pref de v
        slider.value = v; //le slider value est v
        audioM.SetFloat(nameParam, v); //set float du volume
    }

    public void SetVol(float vol) //fonction pour modifier le volume
    {
        audioM.SetFloat(nameParam, vol); //set float du volume
        slider.value = vol; //set le slider value 
        PlayerPrefs.SetFloat(nameParam, vol); //sauvegarder le float dans PlayerPrefs
    }
}
