using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public UnityEvent<float, float> HPChange;
    public UnityEvent EnemyDead;

    private int _healthPoint;
    private int _currentHealth;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    public int HealthPoint => _healthPoint;
    public int CurrentHealth => _currentHealth;
    public Animator Animator => _animator;
    public Rigidbody2D Rigidbody => _rigidbody;
    public Collider2D Collider => _collider;

    public void Init(Animator animator, Collider2D collider, Rigidbody2D rigidbody,int maxHealth)
    {
        _animator = animator;
        _rigidbody = rigidbody;
        _collider = collider;
        _healthPoint = maxHealth;
        _currentHealth = _healthPoint;
    }

    public void HealthChange(int points)
    {
        _animator.SetTrigger("hit");
        _currentHealth += points;
        if (_currentHealth <= 0)
        {
            EnemyDead?.Invoke();
            Kill();
        }


        HPChange?.Invoke(_currentHealth, _healthPoint);
    }

    public void Kill()
    {
        _collider.enabled = false;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.velocity += Vector2.up * 20f;
        _rigidbody.gravityScale = 5f;
        StartCoroutine(DestroyByTime());
    }

    private IEnumerator DestroyByTime()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
