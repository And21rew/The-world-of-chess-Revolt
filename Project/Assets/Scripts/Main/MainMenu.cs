using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelsScreen, settingsScreen;
    [SerializeField] private Sprite[] playerFigures;

    [SerializeField] private GameObject playerFigure;
    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject updateScreen;

    [SerializeField] private Button[] levelButtons;
    [SerializeField] private GameObject[] levelComplete;

    private int scoreToUpdateRank;

    private void Start()
    {
        SetPlayerFigure();
        SetScore();
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        var playerRank = PlayerPrefs.GetInt("PlayerRank") - 1;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;

            if (i < playerRank)
            {
                levelComplete[i].SetActive(true);
            }
        }

        levelButtons[playerRank].interactable = true;
    }

    private void SetPlayerFigure()
    {
        var playerRank = PlayerPrefs.GetInt("PlayerRank") - 1;
        playerFigure.GetComponent<Image>().sprite = playerFigures[playerRank];
    }

    private void SetScore()
    {
        ///
        /// —чет обновить 
        /// 
        scoreToUpdateRank = 10 * PlayerPrefs.GetInt("PlayerRank");

        var globalScore = PlayerPrefs.GetInt("Score");
        scoreText.text = globalScore.ToString() + "/" + scoreToUpdateRank.ToString();

        if (globalScore >= scoreToUpdateRank)
            updateScreen.SetActive(true);
    }

    public void UnlockLevel()
    {
        var globalScore = PlayerPrefs.GetInt("Score");
        globalScore -= scoreToUpdateRank;
        PlayerPrefs.SetInt("Score", globalScore);

        var playerRank = PlayerPrefs.GetInt("PlayerRank");
        playerRank += 1;
        PlayerPrefs.SetInt("PlayerRank", playerRank);

        SetPlayerFigure();
        SetScore();
        UpdateButtons();

        updateScreen.SetActive(false);
    }

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

    public void CloseGame()
    {
        Application.Quit();
    }
}
