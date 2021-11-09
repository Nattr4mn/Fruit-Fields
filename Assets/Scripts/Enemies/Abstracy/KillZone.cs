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
            _animator.SetTrigger("hit");
            _killZoneCollider.enabled = false;
            _enemy.enabled = false;
            _enemyCollider.enabled = false;
            _enemyRigidbody.bodyType = RigidbodyType2D.Dynamic;
            _enemyRigidbody.velocity += Vector2.up * 20f;
            _enemyRigidbody.gravityScale = 5f;
            StartCoroutine(DestroyByTime());
        }
    }

    private IEnumerator DestroyByTime()
    {
        yield return new WaitForSeconds(5f);
        _enemy.gameObject.SetActive(false);
    }
}
