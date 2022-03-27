using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemysColor
{
    White,
    Black
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] whiteEnemys, blackEnemys;

    [SerializeField] private float timeBetweenSpawn;

    private GameObject player;

    private int playerRank;
    private int enemyColor;

    private float playerSize;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerRank = player.GetComponent<FigureRank>().GetRank();
        StartCoroutine(WaitAndSpawn(playerRank));
    }

    private IEnumerator WaitAndSpawn(int _playerRank)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            playerSize = player.GetComponent<FigureSize>().GetSize();
            Spawn(_playerRank);
        }
    }

    private void Spawn(int _playerRank)
    {
        var _enemy = SelectEnemy(_playerRank);
        _enemy.GetComponent<FigureManager>().fromSpawner = true;

        Instantiate(_enemy, transform.position, transform.rotation);
    }

    private GameObject SelectEnemy(int _playerRank)
    {
        enemyColor = Random.Range(0, 2);

        if (enemyColor == (int)EnemysColor.White)
            return whiteEnemys[_playerRank];
        else
            return blackEnemys[_playerRank];
    }

    public float SelectSizeEnemy()
    {
        var firstOption = playerSize - 0.1f;
        var secondOption = playerSize;
        var thirdOption = playerSize + 0.1f;
        var fourthOption = playerSize + 0.2f;

        var variant = Random.Range(0, 4);

        if (variant == 0)
            return firstOption;
        else if (variant == 1)
            return secondOption;
        else if (variant == 2)
            return thirdOption;
        else
            return fourthOption;
    }
}
