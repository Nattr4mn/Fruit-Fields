using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxJumps = 2;
    [SerializeField] private float _groundCheckerRadius = 0.2f;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private LayerMask _groundMask;
    private Animator _playerAnimator;
    private int _jumpsCount = 0;

    public void Initialized(Animator characterAnimator)
    {
        _playerAnimator = characterAnimator;
        _jumpsCount = _maxJumps;
    }

    public void Jump()
    {
        if (CheckGround() || _jumpsCount > 0)
        {
            _jumpsCount--;
            _playerAnimator.SetTrigger("jump");
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }

    private bool CheckGround()
    {
        var ground = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _groundMask);
        if (ground != null)
        {
            _jumpsCount = _maxJumps;
            return true;
        }
        return false;
    }
}
