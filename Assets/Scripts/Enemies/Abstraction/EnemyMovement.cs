using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _movementPoints;
    [SerializeField] private float _pauseTime;
    private int _currentPoint;
    private bool _isStoped = false;

    public IReadOnlyList<Transform> MovementPoints => _movementPoints;
    public bool IsStoped => _isStoped;

    public void Move()
    {
        if (CheckPosition(_movementPoints[_currentPoint].position) && !_isStoped)
        {
            Stop(_pauseTime);
        }

        if(!_isStoped)
        {
            Direction(_movementPoints[_currentPoint].position);
            transform.position = Vector3.MoveTowards(transform.position, _movementPoints[_currentPoint].position, _speed * Time.deltaTime);
        }
    }

    public void MoveToPosition(Vector3 position)
    {
        Direction(position);
        transform.position = Vector3.MoveTowards(transform.position, _movementPoints[_currentPoint].position, _speed * Time.deltaTime);
    }

    public void Stop(float pauseTime)
    {
        _isStoped = true;
        StartCoroutine(Stoped(pauseTime));
    }

    private void Direction(Vector3 position)
    {
        if(transform.position.x > position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(transform.position.x < position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

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

    private IEnumerator Stoped(float pauseTime)
    {
        yield return new WaitForSeconds(pauseTime);
        _isStoped = false;
    }
}
