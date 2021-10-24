using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;
    private Animator _playerAnimator;
    private Vector2 _direction;
    private bool _isGround;

    public void Initialized(Animator characterAnimator)
    {
        _playerAnimator = characterAnimator;
    }

    public void Direction(Vector2 direction)
    {
        if (direction == Vector2.left)
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        else if (direction == Vector2.right)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        _direction = direction * _playerSpeed;
    }

    private void Move()
    {
        if(_rigidbody.velocity.x == 0)
            _playerAnimator.SetBool("running", false);
        else
            _playerAnimator.SetBool("running", true);

        _rigidbody.velocity = new Vector2(_direction.x, _rigidbody.velocity.y);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
