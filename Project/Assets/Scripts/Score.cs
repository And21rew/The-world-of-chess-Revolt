using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateScore(GameObject _enemy)
    {
        score += _enemy.GetComponent<FigureRank>().GetRank();
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = score.ToString();
    }
}
