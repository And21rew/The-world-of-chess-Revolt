using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning : MonoBehaviour
{
    [SerializeField] private GameObject[] learningScreens;

    private int firstPlay;

    private void Start()
    {
        firstPlay = PlayerPrefs.GetInt("Learning");

        if (firstPlay == 0)
        {
            learningScreens[0].SetActive(true);
        }
    }
}
