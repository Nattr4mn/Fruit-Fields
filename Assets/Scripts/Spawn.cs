using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private EnemyMovement _enemy;
    [SerializeField] private bool _isOccupied = false;

    public bool IsOccupied => _isOccupied;
    public EnemyMovement Enemy => _enemy;

    public void Init(EnemyMovement enemy)
    {
        _enemy = enemy;
        _enemy.Init(_points);
        _isOccupied = true;
    }

    public void Clear()
    {
        _enemy = null;
        _isOccupied = false;     
    }
}
