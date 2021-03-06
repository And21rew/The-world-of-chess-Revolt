using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Learning : MonoBehaviour
{
    [SerializeField] private GameObject[] learningScreens;
    [SerializeField] private GameObject backgroundLearning;

    private int firstPlay;

    private void Start()
    {
        firstPlay = PlayerPrefs.GetInt("Learning");

        if (firstPlay == 0)
        {
            backgroundLearning.SetActive(true);
            learningScreens[0].SetActive(true);
        }
    }

    public void SwitchLearningScreen(int index)
    {
        if (index == learningScreens.Length)
            EndLearning(index);
        else
        {
            learningScreens[index - 1].SetActive(false);
            learningScreens[index].SetActive(true);
        }
    }

    private void EndLearning(int index)
    {
        learningScreens[index - 1].SetActive(false);
        backgroundLearning.SetActive(false);
        PlayerPrefs.SetInt("Learning", 1);
    }
}
