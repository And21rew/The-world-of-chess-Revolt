using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject loseScreen, pauseScreen;
    [SerializeField] private GameObject pauseButton;

    private bool isPause = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        RecountScore();
        loseScreen.SetActive(true);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        RecountScore();
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = (float) (isPause ? 1 : 0);
        pauseScreen.SetActive(!isPause);
        pauseButton.SetActive(isPause);
        isPause = !isPause;
    }

    private void RecountScore()
    {
        var globalScore = PlayerPrefs.GetInt("Score");
        globalScore += Score.GetScore();
        PlayerPrefs.SetInt("Score", globalScore);
    }
}
