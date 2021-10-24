using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class ChickenEnemy : Enemy
{
    [SerializeField] private EnemyMovement _movement;

    private void Start()
    {
        transform.position = _movement.MovementPoints[0].position;
    }

    public override void EnemyLogic()
    {
        _movement.Move();
    }
}
