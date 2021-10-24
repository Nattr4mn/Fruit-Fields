using UnityEngine;

[RequireComponent(typeof(EnemyCollision))]
public abstract class Enemy : MonoBehaviour
{
    public Animator Animator => _animator;
    public Rigidbody2D Rigidbody => _rigidbody;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;

    void Update()
    {
        EnemyLogic();
    }

    public abstract void EnemyLogic();
}
