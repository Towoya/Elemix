using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   public Slider _musicSlider, _sfxSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Loadmusic();
        }
        else
        {
            Loadmusic();
        }

        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1);
            Loadsfx();
        }
        else
        {
            Loadsfx();
        }
    }

   public void ToggleMusic()
   {
        AudioManager.Instance.ToggleMusic();
   }

   public void ToggleSFX()
   {
        AudioManager.Instance.ToggleSFX();
   }

   public void MusicVolume()
   {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        Savemusic();
   }
   public void SFXVolume()
   {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
        Savesfx();
   }


    private void Loadmusic()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Loadsfx()
    {
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void Savemusic()
    {
        PlayerPrefs.SetFloat("musicVolume", _musicSlider.value);
    }
    private void Savesfx()
    {
        PlayerPrefs.SetFloat("sfxVolume", _sfxSlider.value);
    }

}
