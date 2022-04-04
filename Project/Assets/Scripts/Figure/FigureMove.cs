using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureMove : MonoBehaviour
{
    protected float speed;

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public virtual void Move() { }
}