using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCollision : MonoBehaviour
{
    public float CollisionDamage => _collisionDamage;
    [SerializeField] private int _collisionDamage;
    [SerializeField] private UnityEvent<Player> _collisionEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _collisionEvent?.Invoke(player);
            player.Health.HealthChange(-_collisionDamage);
        }
    }
}
