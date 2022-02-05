using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Killable))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    private Animator _animator;
    private Killable _killable;

    void Start()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
        _killable = GetComponent<Killable>();
    }

    public void HealthChange(Player player)
    {
        _animator.SetTrigger("hit");
        _currentHealth -= 1;
        if (_currentHealth <= 0)
            _killable.Kill();
    }
}
