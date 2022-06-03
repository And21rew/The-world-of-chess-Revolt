using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private float timeBetweenSpawn;

    private void Start()
    {
        StartCoroutine(WaitAndSpawn());
    }

    private IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);

            if (CheckCanSpawn())
                Spawn();
        }
    }

    private bool CheckCanSpawn()
    {
        var coins = GameObject.FindGameObjectsWithTag("Coin"); ;
        return coins.Length <= 10;
    }

    private void Spawn()
    {
        var spawnPosition = new Vector3(Random.Range(-25f, 25f), Random.Range(-25f, 25f), 0);

        Instantiate(coin, spawnPosition, Quaternion.identity);
    }
}
