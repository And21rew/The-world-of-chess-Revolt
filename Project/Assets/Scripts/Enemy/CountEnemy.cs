using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemy : MonoBehaviour
{
    private bool canCheck = true;
    public static bool canSpawn = true;

    private void Update()
    {
        if (canCheck)
            StartCoroutine(UpdateEnemyCount());
    }

    private IEnumerator UpdateEnemyCount()
    {
        canCheck = false;

        var enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        canSpawn = enemyList.Length <= 30;

        yield return new WaitForSeconds(5f);
        canCheck = true;
    }
}
