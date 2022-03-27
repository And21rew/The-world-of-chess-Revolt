using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure
{
    private float size;
    private float speed;
    private int rank;

    public Figure(GameObject _gameObject, float _size, float _speed, int _rank)
    {
        this.size = _size;
        this.speed = _speed;
        this.rank = _rank;

        InstallSize(_gameObject);
        InstallSpeed(_gameObject);
        InstallRank(_gameObject);
    }

    private void InstallSize(GameObject _gameObject)
    {
        _gameObject.GetComponent<FigureSize>().SetSize(_gameObject, size);
    }

    private void InstallSpeed(GameObject _gameObject)
    {
        _gameObject.GetComponent<FigureMove>().SetSpeed(speed);
    }

    private void InstallRank(GameObject _gameObject)
    {
        _gameObject.GetComponent<FigureRank>().SetRank(rank);
    }
}
