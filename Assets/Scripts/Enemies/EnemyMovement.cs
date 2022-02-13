using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float _speed;
    private List<Transform> _movementPoints;
    private float _pauseTime;
    private int _currentPoint;
    private bool _isStoped = false;

    public IReadOnlyList<Transform> MovementPoints => _movementPoints;
    public bool IsStoped => _isStoped;

    public void Init(float speed, float pauseTime, List<Transform> movementPoints)
    {
        _speed = speed;
        _pauseTime = pauseTime;
        _movementPoints = movementPoints;
    }

    public void Init(List<Transform> movementPoints)
    {
        _movementPoints = movementPoints;
    }

    public void Move()
    {
        if(_movementPoints.Count > 0)
        {
            TryStop(_pauseTime);
            MoveToPosition(_movementPoints[_currentPoint].position);
        }
    }

    private void MoveToPosition(Vector3 position)
    {
        if (!_isStoped)
        {
            Direction(position);
            transform.position = Vector3.MoveTowards(transform.position, position, _speed * Time.deltaTime);
        }
    }

    private void TryStop(float pauseTime)
    {
        if (CheckPosition(_movementPoints[_currentPoint].position) && !_isStoped)
        {
            _isStoped = true;
            StartCoroutine(Stoped(pauseTime));
        }

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
