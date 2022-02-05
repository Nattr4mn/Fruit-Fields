using System.Collections;
using UnityEngine;

public class FatBird : AbstractEnemy
{
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpTime;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _timeOut;
    [SerializeField] private int _groundLayer;
    private float _currentJumpTime;
    private Vector3 _startPosition, _centerPosition, _endPosition;
    private bool _onTheWay = false;
    private bool _isTimeOut = false;

    private void Start()
    {
        Rigidbody.bodyType = RigidbodyType2D.Kinematic;
        _startPosition = transform.position;
    }

    public override void EnemyLogic()
    {

        if (!_onTheWay)
        {
            _currentJumpTime = 0f;
            _startPosition = transform.position;
            _endPosition = new Vector3(_player.position.x, _player.position.y + 2f, _startPosition.z);
            _centerPosition.x = (_startPosition.x + _endPosition.x) / 2f;
            _centerPosition.y = ((_startPosition.y + _endPosition.y) / 2f) + _jumpHeight;
            Animator.SetTrigger("fall");
            _onTheWay = true;
        } else if(_currentJumpTime / _jumpTime < 1f && !_isTimeOut)
        {
            _currentJumpTime += Time.deltaTime;
            _rigidbody.MovePosition(BezierCurve(_startPosition, _centerPosition, _endPosition, _currentJumpTime / _jumpTime));
            //transform.position = BezierCurve(_startPosition, _centerPosition, _endPosition, _currentJumpTime / _jumpTime);
        }
        if (_currentJumpTime / _jumpTime >= 1f && !_isTimeOut)
        {
            Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }


    }

    private IEnumerator TimeOut()
    {
        float process = 0f;
        while(process < _timeOut)
        {
            process += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _onTheWay = false;
        _isTimeOut = false;
        Rigidbody.bodyType = RigidbodyType2D.Kinematic;
        _currentJumpTime = 0f;
    }

    private Vector2 BezierCurve(Vector2 p0, Vector2 p1, Vector2 p2, float t)
    {
        float oneMinusT = 1f - t;

        return (oneMinusT * oneMinusT * p0) + (2 * t * oneMinusT * p1) + (t * t * p2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == _groundLayer && !_isTimeOut && _onTheWay)
        {
            _isTimeOut = true;
            Rigidbody.bodyType = RigidbodyType2D.Kinematic;
            Animator.SetTrigger("ground");
            StartCoroutine(TimeOut());
        }
    }
}
