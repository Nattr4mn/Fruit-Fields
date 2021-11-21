using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _enemyRigidbody;
    [SerializeField] private Collider2D _enemyCollider;
    [SerializeField] private Collider2D _killZoneCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {

        }
    }
}
