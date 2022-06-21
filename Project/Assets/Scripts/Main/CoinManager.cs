using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Text[] coinsText;

    private void Start()
    {
        SetCountCoins();
    }

    public void SetCountCoins()
    {
        var coins = PlayerPrefs.GetInt("Coin");
        coinsText[0].text = " " + coins;
    }

    public void RecountCoins(int count)
    {
        var coins = PlayerPrefs.GetInt("Coin");
        coins += count;
        PlayerPrefs.SetInt("Coin", coins);
        SetCountCoins();
    }
}
