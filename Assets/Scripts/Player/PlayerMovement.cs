using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _direction;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
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
            _animator.SetBool("running", false);
        else
            _animator.SetBool("running", true);

        _rigidbody.velocity = new Vector2(_direction.x, _rigidbody.velocity.y);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
