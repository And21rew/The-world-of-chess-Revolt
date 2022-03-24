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
            var playerSize = this.transform.localScale.x;
            var enemySize = collision.transform.localScale.x;

            var playerRank = this.rank;
            var enemyRank = collision.gameObject.GetComponent<FigureRank>().GetRank();

            if ((playerSize >= enemySize) && (playerRank >= enemyRank))
            {
                Destroy(collision.gameObject);

                PlayerSize.UpdateSize(this.gameObject, enemySize);
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
