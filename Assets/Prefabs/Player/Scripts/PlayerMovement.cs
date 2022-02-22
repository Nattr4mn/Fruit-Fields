using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public bool IsStoped = false;

    [SerializeField] private float _playerSpeed;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _direction;

    public void Init(Animator animator, Rigidbody2D rigidbody)
    {
        _animator = animator;
        _rigidbody = rigidbody;
    }

    public void Direction(Vector2 direction)
    {
        if (direction == Vector2.left)
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        else if (direction == Vector2.right)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        if (direction == Vector2.zero)
            _animator.SetBool("running", false);
        else
            _animator.SetBool("running", true);

        _direction = direction * _playerSpeed;
    }

    public bool TryMove()
    {
        if(!IsStoped)
        {
            _rigidbody.velocity = new Vector2(_direction.x, _rigidbody.velocity.y);
            return true;
        }

        Debug.LogWarning("Object stopped!");
        return false;
    }
}
