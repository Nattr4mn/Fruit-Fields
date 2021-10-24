using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundDetector;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Rigidbody2D _rigidbody;
    private Animator _playerAnimator;
    private int _jumpCount = 0;
    private int _maxJump = 2;

    public void Initialized(Animator characterAnimator)
    {
        _playerAnimator = characterAnimator;
    }

    public void Jump()
    {
        if (CheckGround())
        {
            _playerAnimator.SetTrigger("jump");
            _rigidbody.velocity += Vector2.up * _jumpForce;
            _jumpCount++;
        }
        else if (_jumpCount < _maxJump)
        {
            _rigidbody.velocity += Vector2.up * _jumpForce;
            _jumpCount++;
        }
    }

    private bool CheckGround()
    {
        var ground = Physics2D.OverlapCircle(_groundDetector.position, 0.2f, _groundMask);
        if (ground != null && _rigidbody.velocity.y <= 0)
        {
            _jumpCount = 0;
            return true;
        }
        return false;
    }
}
