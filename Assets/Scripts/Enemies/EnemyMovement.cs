using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMovement : MonoBehaviour
{
    public IReadOnlyList<Transform> MovementPoints => _movementPoints;

    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _movementPoints;
    [SerializeField] private float _pauseTime;
    [SerializeField] private Animator _animator;
    private int _currentPoint;
    private bool _isStoped = false;

    public void Move()
    {
        if (CheckPosition(_movementPoints[_currentPoint].position) && !_isStoped)
        {
            _animator.SetBool("running", false);
            _isStoped = true;
            StartCoroutine(Stoped());
        }

        if(!_isStoped)
        {
            Direction();
            transform.position = Vector3.MoveTowards(transform.position, _movementPoints[_currentPoint].position, _speed * Time.deltaTime);
        }
    }

    private void Direction()
    {
        if(transform.position.x > _movementPoints[_currentPoint].position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(transform.position.x < _movementPoints[_currentPoint].position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        _animator.SetBool("running", true);
    }

    private bool CheckPosition(Vector3 position)
    {
        if (transform.position == position)
        {
            _currentPoint++;

            if (_currentPoint >= _movementPoints.Count)
            {
                _currentPoint = 0;
            }
            return true;
        }

        return false;
    }

    private IEnumerator Stoped()
    {
        yield return new WaitForSeconds(_pauseTime);
        _isStoped = false;
    }
}
