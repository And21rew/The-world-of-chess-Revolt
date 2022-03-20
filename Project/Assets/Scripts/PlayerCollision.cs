using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : FigureRank
{
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
                ///
                /// Функция обновления счета
                ///
            }
            else
            {
                Destroy(this.gameObject);
                ///
                /// Функция проигрыша
                ///
            }
        }
    }
}
