using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeleeAttack))]
[RequireComponent(typeof(EnemyMovement))]
public class Saw : MonoBehaviour
{
    [SerializeField] private List<Transform> _movementPoints;
    [SerializeField] private float _speed;
    private EnemyMovement _movement;


    private void Awake()
    {
        _movement = GetComponent<EnemyMovement>();
        _movement.Init(_speed, 0f, _movementPoints);
    }

    private void Update()
    {
        _movement.Move();
    }
}
