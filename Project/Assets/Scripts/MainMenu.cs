using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelsScreen, settingsScreen;

    public void SwitchLevelsScreen()
    {
        if (levelsScreen.activeInHierarchy)
            levelsScreen.SetActive(false);
        else
            levelsScreen.SetActive(true);
    }

    public void SwitchSettingsScreen()
    {
        if (settingsScreen.activeInHierarchy)
            settingsScreen.SetActive(false);
        else
            settingsScreen.SetActive(true);
    }

    public void EnterInLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
