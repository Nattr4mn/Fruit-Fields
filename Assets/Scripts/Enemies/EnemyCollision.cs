using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float CollisionDamage => _collisionDamage;
    [SerializeField] private int _collisionDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Health.HealthChange(-_collisionDamage);
            Handheld.Vibrate();
        }
    }
}
