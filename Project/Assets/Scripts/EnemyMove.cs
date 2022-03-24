using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : FigureMove
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        this.Move(speed);
    }

    public override void Move(float _speed)
    {
        if (player != null) 
        {
            var distanceToPlayer = CalculateDistance();

            if (distanceToPlayer <= 8f)
            {
                this.transform.position += (player.transform.position - this.transform.position).normalized * _speed * Time.deltaTime;
            }
        }
    }

    private float CalculateDistance()
    {
        return Vector3.Distance(this.transform.position, player.transform.position);
    }
}
