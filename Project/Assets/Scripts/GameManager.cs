using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject loseScreen;

    public void LoseGame()
    {
        Time.timeScale = 0f;
        RecountScore();
        loseScreen.SetActive(true);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    private void RecountScore()
    {
        var globalScore = PlayerPrefs.GetInt("Score");
        globalScore += Score.GetScore();
        PlayerPrefs.SetInt("Score", globalScore);
    }
}
