using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private PatrollingEnemy _enemy;
    [SerializeField] private bool _isOccupied = false;

    public bool IsOccupied => _isOccupied;
    public PatrollingEnemy Enemy => _enemy;

    public void Init(PatrollingEnemy enemy, AudioSource audioSource)
    {
        _enemy = enemy;
        _enemy.Movement.Init(_points);
        _enemy.Health.InitSound(audioSource, _enemy.HitClip);
        _isOccupied = true;
    }

    public void Clear()
    {
        _enemy = null;
        _isOccupied = false;     
    }
}
