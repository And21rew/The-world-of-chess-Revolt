using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] menuScreens;
    [SerializeField] private Sprite[] playerFigures;

    [SerializeField] private GameObject playerFigure;
    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject updateScreen;

    [SerializeField] private Button[] levelButtons;
    [SerializeField] private GameObject[] levelComplete;

    [SerializeField] private Button[] localizationButtons;

    [SerializeField] private Button fisrtSkill;

    [SerializeField] private GameObject gameOver;

    [SerializeField] private Text coinsCount;
    [SerializeField] private GameObject firstSkillImage;
    [SerializeField] private Sprite[] shopFill;

    private int scoreToUpdateRank;

    private void Start()
    {
        SetPlayerFigure();
        SetScore();
        UpdateButtons();
        CheckLocalization();
        SetShop();
    }

    private void UpdateButtons()
    {
        var playerRank = PlayerPrefs.GetInt("PlayerRank") - 1;
        if (playerRank > 5)
            playerRank = 5;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;

            if (i < playerRank)
            {
                levelComplete[i].SetActive(true);
            }
        }

        if (playerRank < 5)
            levelButtons[playerRank].interactable = true;
    }

    private void SetPlayerFigure()
    {
        var playerRank = PlayerPrefs.GetInt("PlayerRank") - 1;
        if (playerRank > 4)
            playerRank = 4;
        playerFigure.GetComponent<Image>().sprite = playerFigures[playerRank];
    }

    private void SetScore()
    {
        var playerRank = PlayerPrefs.GetInt("PlayerRank");

        if (playerRank < 6)
        {
            scoreToUpdateRank = 20 * playerRank * playerRank;

            var globalScore = PlayerPrefs.GetInt("Score");
            scoreText.text = globalScore.ToString() + "/" + scoreToUpdateRank.ToString();

            if (globalScore >= scoreToUpdateRank)
                updateScreen.SetActive(true);
        }
        else
        {
            UpdateButtons();

            var language = PlayerPrefs.GetString("Language");

            if (language == "Ru")
                scoreText.text = "Королева Королев";
            else
                scoreText.text = "Queen of Queens";
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
        SetScore();
    }

    public void SwitchScreens(int index)
    {
        menuScreens[index].SetActive(!menuScreens[index].activeInHierarchy);
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
        SetScore();
    }

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public void AddScore()
    {
        var globalScore = PlayerPrefs.GetInt("Score");
        globalScore += 10;
        PlayerPrefs.SetInt("Score", globalScore);

        SetScore();
    }

    public void AddCoins()
    {
        var coins = PlayerPrefs.GetInt("Coin");
        coins += 10;
        PlayerPrefs.SetInt("Coin", coins);

        SetShop();
    }

    public void SetShop()
    {
        firstSkillImage.GetComponent<Image>().sprite = PlayerPrefs.GetInt("skill_1") == 0 ? shopFill[0] : shopFill[1];
        fisrtSkill.interactable = PlayerPrefs.GetInt("skill_1") == 0;
        coinsCount.text = " " + PlayerPrefs.GetInt("Coin");
    }
}
