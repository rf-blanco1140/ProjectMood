using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider volSlider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        }
        else
        {
            Load();
        }
    }

 
    public void ChangeVol()
    {
        AudioListener.volume = volSlider.value;
        Save();
    }
    private void Load()
    {
        volSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
   private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volSlider.value);
    }
}
