using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private static int score;

    private void Start()
    {
        score = 0;
        UpdateUI();
    }

    public void UpdateScore(GameObject _enemy)
    {
        score += _enemy.GetComponent<FigureRank>().GetRank();
        UpdateUI();
    }

    public static int GetScore()
    {
        return score;
    }

    private void UpdateUI()
    {
        scoreText.text = score.ToString();
    }
}
