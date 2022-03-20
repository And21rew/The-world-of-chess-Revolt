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

        InstallSize(_gameObject, size);
        InstallSpeed(_gameObject, speed);
        InstallRank(_gameObject, rank);
    }

    private void InstallSize(GameObject _gameObject, float _size)
    {
        _gameObject.transform.localScale = new Vector3(_size, _size, _size);
    }

    private void InstallSpeed(GameObject _gameObject, float _speed)
    {
        _gameObject.GetComponent<FigureMove>().SetSpeed(_speed);
    }

    private void InstallRank(GameObject _gameObject, int _rank)
    {
        _gameObject.GetComponent<FigureRank>()?.SetRank(_rank);
    }
}
