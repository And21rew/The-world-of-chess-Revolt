using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    public static void UpdateSize(GameObject _player, float _enemySize)
    {
        if (_player.transform.localScale.x < 3f)
        {
            var newScale = CalculateNewScale(_player, _enemySize);
            _player.GetComponent<Transform>().localScale = newScale;
        }
    }

    private static Vector3 CalculateNewScale(GameObject _player, float _enemySize)
    {
        float addPart;

        if (_enemySize == 1)
            addPart = 0.01f;
        else
            addPart = (float)Math.Round(_enemySize % (int)_enemySize / 10f, 2);

        var newScaleX = _player.GetComponent<Transform>().localScale.x + addPart;
        var newScaleY = _player.GetComponent<Transform>().localScale.y + addPart;
        var newScaleZ = _player.GetComponent<Transform>().localScale.z + addPart;

        return new Vector3(newScaleX, newScaleY, newScaleZ);
    }
}
