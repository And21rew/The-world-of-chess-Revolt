using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSizeFigure : MonoBehaviour
{
    public static void UpdateSize(float _enemySize)
    {
        float addPart = 0.01f;

        if (_enemySize == 1)
        {
            Debug.Log(addPart);
        }
        else
        {
            addPart = (float)Math.Round(_enemySize % (int)_enemySize / 10f, 2);
            Debug.Log(addPart);
        }
    }
}
