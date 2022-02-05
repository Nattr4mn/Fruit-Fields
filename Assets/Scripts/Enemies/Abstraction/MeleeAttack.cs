using System;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public event Action AttackEvent;
    [SerializeField] private int _damage;

    public float Damage => _damage;

    private void OnValidate()
    {
        if (_damage < 0)
            _damage = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Health.Kill();
            AttackEvent?.Invoke();
        }
    }
}
