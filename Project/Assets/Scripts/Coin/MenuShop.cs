using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShop : MonoBehaviour
{
    private CoinManager coinManager;
    private MainMenu menu;

    private void Start()
    {
        GameObject menuManager = GameObject.Find("MenuManager");
        coinManager = menuManager.GetComponent<CoinManager>();
        menu = menuManager.GetComponent<MainMenu>();
    }

    public void BuyFirstSkill(int count)
    {
        var coins = PlayerPrefs.GetInt("Coin");

        if (coins >= count)
        {
            coinManager.RecountCoins(-count);
            PlayerPrefs.SetInt("skill_1", 1);
            menu.SetShop();
        }
    }
}
