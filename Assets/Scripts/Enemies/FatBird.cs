using System.Collections;
using UnityEngine;

public class FatBird : AbstractEnemy
{
    [SerializeField] private float _maxJumpTime;
    [SerializeField] private float _maxJumpHeight;
    [SerializeField] private float _distanceToMaxJump;
    [SerializeField] private int _groundLayer;
    [SerializeField] private float _timeOut;
    [SerializeField] private float _groundOffset;
    [SerializeField] private KillZone _killzone;
    [SerializeField] private Transform _player;
    [SerializeField] private AudioClip _jump;
    private float _currentJumpTime;
    private float _jumpHeight;
    private float _jumpTime;
    private Vector3 _startPosition, _centerPosition, _endPosition;
    private bool _onTheWay = false;
    private bool _isTimeOut = false;

    protected override void Awake()
    {
        base.Awake();
        Rigidbody.bodyType = RigidbodyType2D.Kinematic;
        _startPosition = transform.position;
        _jumpHeight = _maxJumpHeight;
        _jumpTime = _maxJumpTime;
    }

    public override void EnemyLogic()
    {
        var jumpTimeNormolize = _currentJumpTime / _jumpTime;
        if (!_onTheWay)
        {
            _onTheWay = true;
            _currentJumpTime = 0f;
            _killzone.gameObject.SetActive(false);
            SetPoints();
            Animator.SetTrigger("fall");
            AudioSource.PlayOneShot(_jump);
        } 
        else if(jumpTimeNormolize < 1f && !_isTimeOut)
        {
            _currentJumpTime += Time.deltaTime;
            Rigidbody.MovePosition(BezierCurve(_startPosition, _centerPosition, _endPosition, _currentJumpTime / _jumpTime));
        }
        if (jumpTimeNormolize >= 1f && !_isTimeOut)
        {
            Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void CheckDistance(Vector3 startPosition, Vector3 endPosition)
    {
        var distance = Mathf.Clamp(Vector3.Distance(startPosition, endPosition), 0f, _distanceToMaxJump);
        var distance01 = distance / _distanceToMaxJump;
        _jumpHeight = _maxJumpHeight * distance01;
        _jumpTime = _maxJumpTime * distance01;
    }

    private void SetPoints()
    {
        _startPosition = transform.position;
        _endPosition = new Vector3(_player.position.x, _player.position.y + _groundOffset, _startPosition.z);
        _centerPosition.x = (_startPosition.x + _endPosition.x) / 2f;
        _centerPosition.y = ((_startPosition.y + _endPosition.y) / 2f) + _jumpHeight;
        CheckDistance(_startPosition, _endPosition);
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
            _killzone.gameObject.SetActive(true);
            Rigidbody.velocity = Vector2.zero;
            Rigidbody.bodyType = RigidbodyType2D.Kinematic;
            Animator.SetTrigger("ground");
            AudioSource.PlayOneShot(HitClip);
            StartCoroutine(TimeOut());
        }
    }
}
