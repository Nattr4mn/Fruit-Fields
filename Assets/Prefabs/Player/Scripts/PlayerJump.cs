using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxJumps = 2;
    [SerializeField] private GroundChecker _groundChecker;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _inAir = false;
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
        else if (!CheckGround() && !_inAir)
        {
            _jumpsCount -= _maxJumps;
            _animator.SetTrigger("jump");
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }

    private bool CheckGround()
    {
        var groundCheck = _groundChecker.CheckGround();
        if (groundCheck)
        {
            _jumpsCount = _maxJumps;
            _inAir = false;
            return true;
        }
        _inAir = true;
        return false;
    }
}
