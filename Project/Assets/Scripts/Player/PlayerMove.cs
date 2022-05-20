using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : FigureMove
{
    Rigidbody2D _rigidbody;
    Animator _animator;
    public Joystick joystick;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0f;
    }

    private void FixedUpdate()
    {
        this.Move();
    }

    public override void Move()
    {
        /*
        if (joystick.Horizontal != 0)
            _rigidbody.velocity = new Vector2(joystick.Horizontal * speed, _rigidbody.velocity.y);

        if (joystick.Vertical != 0)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, joystick.Vertical * speed);

        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y);
        */
        _rigidbody.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
        /*
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
        */
    }
}
