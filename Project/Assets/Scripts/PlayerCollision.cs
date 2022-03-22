using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : FigureRank
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

                UpdateSizeFigure.UpdateSize(this.gameObject, enemySize);
                ///
                /// Функция обновления счета
                ///
            }
            else
            {
                Destroy(this.gameObject);
                gameManager.LoseGame();
                ///
                /// Функция проигрыша
                ///
            }
        }
    }
}
