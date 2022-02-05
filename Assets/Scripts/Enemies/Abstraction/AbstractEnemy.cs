using UnityEngine;

[RequireComponent(typeof(MeleeAttack))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Killable))]
[RequireComponent(typeof(EnemyHealth))]
public abstract class AbstractEnemy : MonoBehaviour
{
    public Animator Animator => _animator;
    public Rigidbody2D Rigidbody => _rigidbody;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemyLogic();
    }

    public abstract void EnemyLogic();
}
