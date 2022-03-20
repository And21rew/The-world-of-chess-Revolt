using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : FigureMove
{
    Rigidbody2D _rigidbody;
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0f;
    }

    private void Update()
    {
        this.Move(speed);
    }

    public override void Move(float _speed)
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, Input.GetAxis("Vertical") * _speed);
    }
}
