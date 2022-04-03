using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStart : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetInt("MusicVolume", 5);
        }

        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            PlayerPrefs.SetInt("SoundVolume", 5);
        }

        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }

        if (!PlayerPrefs.HasKey("PlayerRank"))
        {
            PlayerPrefs.SetInt("PlayerRank", 1);
        }

        if (!PlayerPrefs.HasKey("block2"))
        {
            PlayerPrefs.SetInt("block2", 0);
        }

        if (!PlayerPrefs.HasKey("block3"))
        {
            PlayerPrefs.SetInt("block3", 0);
        }

        if (!PlayerPrefs.HasKey("block4"))
        {
            PlayerPrefs.SetInt("block4", 0);
        }

        if (!PlayerPrefs.HasKey("block5"))
        {
            PlayerPrefs.SetInt("block5", 0);
        }
    }
}
