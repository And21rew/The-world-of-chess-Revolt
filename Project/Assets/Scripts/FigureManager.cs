using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureManager : MonoBehaviour
{
    [SerializeField] private float size;
    [SerializeField] private float speed;
    [SerializeField] private int rank;

    private void Start()
    {
        InstallFeatures(size, speed, rank);
    }

    private void InstallFeatures(float _size, float _speed, int _rank)
    {
        Figure figure = new Figure(this.gameObject, _size, _speed, _rank);
    }
}
