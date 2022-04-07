using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    [SerializeField] private AudioSource[] soundRoots, musicRoots;

    private int musicVolume;
    private int soundVolume;

    private void Awake()
    {
        GetSoundVolume();
    }

    private void Start()
    {
        for (int i = 0; i < soundRoots.Length; i++)
        {
            soundRoots[i].volume = (float) soundVolume / 10;
        }

        for (int i = 0; i < musicRoots.Length; i++)
        {
            musicRoots[i].volume = (float) musicVolume / 10;
        }
    }

    private void GetSoundVolume()
    {
        musicVolume = PlayerPrefs.GetInt("MusicVolume");
        soundVolume = PlayerPrefs.GetInt("SoundVolume");
    }
}
