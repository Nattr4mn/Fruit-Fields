using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBird : Enemy
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    private Vector3 _startPosition, _endPosition;
    private bool _onTheWay = false;
    private bool _fall = false;

    private void Start()
    {
        Rigidbody.bodyType = RigidbodyType2D.Kinematic;
        _startPosition = transform.position;
    }

    public override void EnemyLogic()
    {
        if(!_onTheWay)
        {
            _endPosition = new Vector3(_player.position.x, _startPosition.y, _startPosition.z);
            _onTheWay = true;
        }
        else
        {
            if(transform.position.x == _endPosition.x)
            {
                _fall = true;
                Animator.SetTrigger("fall");
                Rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }

            if(!_fall)
            {
                transform.position = Vector3.MoveTowards(transform.position, _endPosition, _speed * Time.deltaTime);
            }
        }
        
    }
}
