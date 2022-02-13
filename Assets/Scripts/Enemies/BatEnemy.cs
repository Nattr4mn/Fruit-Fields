using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class BatEnemy : AbstractEnemy
{
    [Header("Movement settings")]
    [SerializeField] private List<Transform> _movementPoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _pauseTime;
    [SerializeField] private TargetZone _targetZone;
    private EnemyMovement _movement;
    private bool _inMove = false;
    private bool _isSleep = true;
    private Vector3 _startPosition;


    protected override void Awake()
    {
        base.Awake();
        _movement = GetComponent<EnemyMovement>();
        _movement.Init(_speed, _pauseTime, _movementPoints);
        _startPosition = _movement.MovementPoints[0].position;
    }

    public void ToMove()
    {
        Animator.SetBool("flying", true);
        _inMove = true;
        _isSleep = true;
    }

    public override void EnemyLogic()
    {
        if (_targetZone.IsTriggered)
        {
            if (!_inMove && _isSleep)
            {
                Animator.SetTrigger("ceilingOut");
                _isSleep = false;
            }
            else if(_inMove)
            {
                _movement.Move();
            }
        }
        else
        {
            if(transform.position == _startPosition && _inMove)
            {
                Animator.SetTrigger("ceilingIn");
                _inMove = false;
            }
            else if(transform.position != _startPosition)
            {
                _movement.Move();
            }
        }  
    }
}
