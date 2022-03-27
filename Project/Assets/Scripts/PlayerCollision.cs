using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : FigureRank
{
    private GameManager gameManager;
    private Score score;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float playerSize = this.gameObject.GetComponent<FigureSize>().GetSize();
            float enemySize = collision.gameObject.GetComponent<FigureSize>().GetSize();

            int playerRank = this.rank;
            int enemyRank = collision.gameObject.GetComponent<FigureRank>().GetRank();

            if ((playerSize >= enemySize) && (playerRank >= enemyRank))
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
}
