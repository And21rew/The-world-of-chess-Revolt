using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStart : MonoBehaviour
{
    private void Awake()
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

        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetString("Language", "Eng");
        }

        if (!PlayerPrefs.HasKey("Learning"))
        {
            PlayerPrefs.SetInt("Learning", 0);
        }
    }
}
