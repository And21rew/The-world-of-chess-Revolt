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

    [SerializeField] private Button[] localizationButtons;

    [SerializeField] private GameObject gameOver;

    private int scoreToUpdateRank;

    private void Start()
    {
        SetPlayerFigure();
        SetScore();
        UpdateButtons();
        CheckLocalization();
    }

    private void UpdateButtons()
    {
        var playerRank = PlayerPrefs.GetInt("PlayerRank") - 1;
        if (playerRank >= 5)
            playerRank = 4;

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
        if (playerRank >= 5)
            playerRank = 4;
        playerFigure.GetComponent<Image>().sprite = playerFigures[playerRank];
    }

    private void SetScore()
    {
        ///
        /// —чет обновить 
        /// 
        var playerRank = PlayerPrefs.GetInt("PlayerRank");

        if (playerRank < 6)
        {
            scoreToUpdateRank = 10 * PlayerPrefs.GetInt("PlayerRank");

            var globalScore = PlayerPrefs.GetInt("Score");
            scoreText.text = globalScore.ToString() + "/" + scoreToUpdateRank.ToString();

            if (globalScore >= scoreToUpdateRank)
                updateScreen.SetActive(true);
        }
    }

    public void UnlockLevel()
    {
        var playerRank = PlayerPrefs.GetInt("PlayerRank");

        if (playerRank == 5)
        {
            UpdateButtons();
            playerRank += 1;
            PlayerPrefs.SetInt("PlayerRank", playerRank);
            gameOver.SetActive(true);
            updateScreen.SetActive(false);
        }
        else
        {
            var globalScore = PlayerPrefs.GetInt("Score");
            globalScore -= scoreToUpdateRank;
            PlayerPrefs.SetInt("Score", globalScore);

            playerRank += 1;
            PlayerPrefs.SetInt("PlayerRank", playerRank);

            SetPlayerFigure();
            SetScore();
            UpdateButtons();

            updateScreen.SetActive(false);
        }
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

    public void CheckLocalization()
    {
        localizationButtons[0].interactable = PlayerPrefs.GetString("Language") != "Ru";
        localizationButtons[1].interactable = PlayerPrefs.GetString("Language") != "Eng";
    }

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
