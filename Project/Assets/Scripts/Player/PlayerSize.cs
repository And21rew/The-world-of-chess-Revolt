using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    public void UpdateSize(float _enemySize)
    {
        var newScale = CalculateNewScale(_enemySize);
        this.gameObject.GetComponent<FigureSize>().SetSize(this.gameObject, newScale.x);
    }

    private Vector3 CalculateNewScale(float _enemySize)
    {
        float addPart = 0.01f;

        if (_enemySize > 1)
            addPart = (float)Math.Round(_enemySize % (int)_enemySize / 10f, 2);

        var newScaleX = this.gameObject.GetComponent<Transform>().localScale.x + addPart;
        var newScaleY = this.gameObject.GetComponent<Transform>().localScale.y + addPart;
        var newScaleZ = this.gameObject.GetComponent<Transform>().localScale.z + addPart;

        return new Vector3(newScaleX, newScaleY, newScaleZ);
    }
}
