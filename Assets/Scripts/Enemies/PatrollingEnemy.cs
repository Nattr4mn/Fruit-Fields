using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class PatrollingEnemy : AbstractEnemy
{
    [Header("Movement settings")]
    [SerializeField] private List<Transform> _movementPoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _pauseTime;
    private EnemyMovement _movement;

    public EnemyMovement Movement => _movement;

    protected override void Awake()
    {
        base.Awake();
        _movement = GetComponent<EnemyMovement>();
        _movement.Init(_speed, _pauseTime, _movementPoints);
    }

    public override void EnemyLogic()
    {
        if(_movement.IsStoped)
            Animator.SetBool("running", false);
        else
            Animator.SetBool("running", true);

        _movement.Move();
    }
}
