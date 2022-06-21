using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureManager : MonoBehaviour
{
    [SerializeField] protected float size;
    [SerializeField] protected float speed;
    [SerializeField] protected int rank;

    public bool fromSpawner = false;
    public bool isPlayer = false;

    private void Start()
    {
        var spawner = GameObject.FindGameObjectWithTag("Spawner");

        if (fromSpawner)
        {
            size = spawner.GetComponent<EnemySpawner>().SelectSizeEnemy();
            //speed = spawner.GetComponent<EnemySpawner>().SelectSpeedEnemy();
        }

        if (isPlayer)
        {
            var playerRank = PlayerPrefs.GetInt("PlayerRank");
            /*
            if (playerRank >= 5)
                playerRank = 4;
            */
            rank = playerRank;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = this.gameObject.GetComponent<PlayerRank>().playerFigures[playerRank - 1];
        }

        InstallFeatures(this.gameObject, size, speed, rank);
    }

    protected void InstallFeatures(GameObject _gameObject, float _size, float _speed, int _rank)
    {
        Figure figure = new Figure(_gameObject, _size, _speed, _rank);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetRank()
    {
        return rank;
    }
}
