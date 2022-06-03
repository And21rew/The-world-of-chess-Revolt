using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : FigureRank
{
    private GameManager gameManager;
    private Score score;
    private CoinManager coinManager;

    private void Start()
    {
        GameObject mainManager = GameObject.Find("GameManager");
        gameManager = mainManager.GetComponent<GameManager>();
        score = mainManager.GetComponent<Score>();
        coinManager = mainManager.GetComponent<CoinManager>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float playerSize = this.gameObject.GetComponent<FigureSize>().GetSize();
            float enemySize = collision.gameObject.GetComponent<FigureSize>().GetSize();

            int playerRank = this.rank;
            int enemyRank = collision.gameObject.GetComponent<FigureRank>().GetRank();

            if ((playerRank > enemyRank) || ((playerSize >= enemySize) && (playerRank >= enemyRank)))
            {
                Destroy(collision.gameObject);

                this.gameObject.GetComponent<PlayerSize>().UpdateSize(enemySize);
                score.UpdateScore(collision.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
                gameManager.LoseGame();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);

            coinManager.RecountCoins(1);
            coinManager.SetCountCoins();
        }
    }
}
