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

        if (!PlayerPrefs.HasKey("block1level"))
        {
            PlayerPrefs.SetInt("block1level", 0);
        }
        
        if (!PlayerPrefs.HasKey("block2level"))
        {
            PlayerPrefs.SetInt("block2level", 1);
        }

        if (!PlayerPrefs.HasKey("block3level"))
        {
            PlayerPrefs.SetInt("block3level", 1);
        }

        if (!PlayerPrefs.HasKey("block4level"))
        {
            PlayerPrefs.SetInt("block4level", 1);
        }

        if (!PlayerPrefs.HasKey("block5level"))
        {
            PlayerPrefs.SetInt("block5level", 1);
        }
    }
}
