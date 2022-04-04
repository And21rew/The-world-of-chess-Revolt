using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : FigureMove
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        this.Move();
    }

    public override void Move()
    {
        if (player != null) 
        {
            var distanceToPlayer = CalculateDistance();

            if (distanceToPlayer <= 8f)
            {
                this.transform.position += speed * Time.deltaTime * (player.transform.position - this.transform.position).normalized;
            }
        }
    }

    private float CalculateDistance()
    {
        return Vector3.Distance(this.transform.position, player.transform.position);
    }
}
