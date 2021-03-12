using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioM = null; 
    [SerializeField] private string nameParam = null;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        float v = PlayerPrefs.GetFloat(nameParam, 0);
        slider.value = v;
        audioM.SetFloat(nameParam, v);
    }

    public void SetVol(float vol)
    {
        audioM.SetFloat(nameParam, vol);
        slider.value = vol;
        PlayerPrefs.SetFloat(nameParam, vol);
    }
}
