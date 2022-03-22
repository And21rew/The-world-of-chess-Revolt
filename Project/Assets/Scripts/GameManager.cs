using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject loseScreen;

    public void LoseGame()
    {
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
    }
}
