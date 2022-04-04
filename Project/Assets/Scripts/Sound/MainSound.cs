using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSound : MonoBehaviour
{
    [SerializeField] private Slider soundSlider, musicSlider;
    [SerializeField] private Text soundSliderText, musicSliderText;
    [SerializeField] private AudioSource musicSource, soundSource;

    protected int musicVolume = PlayerPrefs.GetInt("MusicVolume");
    protected int soundVolume = PlayerPrefs.GetInt("SoundVolume");

    private void Start()
    {
        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;

        musicSource.volume = (float)musicVolume / 10;
        soundSource.volume = (float)soundVolume / 10;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("MusicVolume", (int)musicSlider.value);
        PlayerPrefs.SetInt("SoundVolume", (int)soundSlider.value);

        soundSliderText.text = soundSlider.value.ToString();
        musicSliderText.text = musicSlider.value.ToString();

        musicSource.volume = (float)musicVolume / 10;
        soundSource.volume = (float)soundVolume / 10;
    }
}
