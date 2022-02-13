using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Killable : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AbstractEnemy _enemy;
    private Rigidbody2D _enemyRigidbody;
    private Collider2D _enemyCollider;

    private void Start()
    {
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _enemyCollider = GetComponent<Collider2D>();
    }

    public void Kill()
    {
        _enemy.enabled = false;
        _enemyCollider.enabled = false;
        _enemyRigidbody.bodyType = RigidbodyType2D.Dynamic;
        _enemyRigidbody.velocity += Vector2.up * 20f;
        _enemyRigidbody.gravityScale = 5f;
        StartCoroutine(DestroyByTime());
    }

    private IEnumerator DestroyByTime()
    {
        yield return new WaitForSeconds(5f);
        _enemy.gameObject.SetActive(false);
    }
}
