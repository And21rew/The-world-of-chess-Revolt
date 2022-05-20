using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EnemysColor
{
    White,
    Black
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] whiteEnemys, blackEnemys;

    [SerializeField] private float timeBetweenSpawn;

    private GameObject[] enemyList;

    private GameObject player;

    private int enemyRank;
    private int enemyColor;

    private float playerSize;

    private bool canSpawn = true;
    private bool check = true;

    private void Start()
    {
        StartCoroutine(WaitAndSpawn());
    }

    private void Update()
    {
        if (check)
            StartCoroutine(CheckCanSpawn());
    }

    private void FindPlayer()
    {
        player = GameObject.Find("Player");
        enemyRank = SceneManager.GetActiveScene().buildIndex - 1;
    }

    private IEnumerator CheckCanSpawn()
    {
        check = false;
        yield return new WaitForSeconds(timeBetweenSpawn);
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");;
        canSpawn = enemyList.Length <= 30;
        check = true;
    }

    private IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);

            if (canSpawn)
            {
                FindPlayer();
                playerSize = player.GetComponent<FigureSize>().GetSize();
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        var _enemy = SelectEnemy();
        _enemy.GetComponent<FigureManager>().fromSpawner = true;

        Instantiate(_enemy, transform.position, transform.rotation);
    }

    private GameObject SelectEnemy()
    {
        enemyColor = Random.Range(0, 2);

        if (enemyColor == (int)EnemysColor.White)
            return whiteEnemys[enemyRank];
        else
            return blackEnemys[enemyRank];
    }

    public float SelectSizeEnemy()
    {
        var firstOption = playerSize - 0.4f;
        var secondOption = playerSize - 0.2f;
        var thirdOption = playerSize + 0.2f;
        var fourthOption = playerSize + 0.4f;

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
