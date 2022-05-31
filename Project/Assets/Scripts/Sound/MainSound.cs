using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSound : MonoBehaviour
{
    [SerializeField] private Slider soundSlider, musicSlider;
    [SerializeField] private Text soundSliderHandleText, musicSliderHandleText;
    [SerializeField] private AudioSource musicSource, soundSource;

    private int musicVolume;
    private int soundVolume;

    private void Start()
    {
        GetSoundVolume();
        SetValueToSliders();
    }

    private void Update()
    {
        if (musicSlider.value != musicVolume || soundSlider.value != soundVolume)
        {
            SetSoundVolume();
            GetSoundVolume();
            SetValueToSliders();
        }
    }

    private void GetSoundVolume()
    {
        musicVolume = PlayerPrefs.GetInt("MusicVolume");
        soundVolume = PlayerPrefs.GetInt("SoundVolume");
    }

    private void SetSoundVolume()
    {
        PlayerPrefs.SetInt("MusicVolume", (int)musicSlider.value);
        PlayerPrefs.SetInt("SoundVolume", (int)soundSlider.value);
    }

    private void SetValueToSliders()
    {
        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;

        soundSliderHandleText.text = soundSlider.value.ToString();
        musicSliderHandleText.text = musicSlider.value.ToString();

        musicSource.volume = (float)musicVolume / 10;
        soundSource.volume = (float)soundVolume / 10;
    }
}
