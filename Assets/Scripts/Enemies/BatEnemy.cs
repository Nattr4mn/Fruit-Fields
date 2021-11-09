using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class BatEnemy : Enemy
{
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private TargetZone _targetZone;
    private bool _inMove = false;
    private bool _isSleep = true;
    private Vector3 _startPosition;

    private void Start()
    {
        if (_movement == null)
            _movement = GetComponent<EnemyMovement>();

        if (_targetZone == null)
            _targetZone = GetComponentInChildren<TargetZone>();

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
