using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureMove : MonoBehaviour
{
    protected float speed;

    public void SetSpeed(float _speed)
    {
        this.speed = _speed;
    }

    public virtual void Move(float _speed) { }
}