using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxJumps = 2;
    [SerializeField] private float _groundCheckerRadius = 0.2f;
    [SerializeField] private Transform _groundChecker;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private int _jumpsCount = 0;

    private void Start()
    {
        _jumpsCount = _maxJumps;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (CheckGround() || _jumpsCount > 0)
        {
            _jumpsCount--;
            _animator.SetTrigger("jump");
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
        else if(!CheckGround() && _jumpsCount == 0)
        {
            _jumpsCount-=_maxJumps;
            _animator.SetTrigger("jump");
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }

    private bool CheckGround()
    {
        var ground = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius);
        if (ground != null)
        {
            _jumpsCount = _maxJumps;
            return true;
        }
        return false;
    }
}
