using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MainSound
{
    [SerializeField] private AudioSource[] soundRoots, musicRoots;

    private void Start()
    {
        for (int i = 0; i < soundRoots.Length; i++)
        {
            soundRoots[i].volume = (float)soundVolume / 10;
        }

        for (int i = 0; i < musicRoots.Length; i++)
        {
            musicRoots[i].volume = (float)musicVolume / 10;
        }
    }
}
