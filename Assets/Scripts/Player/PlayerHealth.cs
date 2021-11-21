using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TossableObject))]
public class PlayerHealth : MonoBehaviour
{
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public UnityEvent HpChange;

    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    private Animator _animator;
    private TossableObject _tossableObject;
    private bool _isDamaged = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _tossableObject = GetComponent<TossableObject>();
        _currentHealth = _maxHealth;
    }

    public void HealthChange(int healthPoints)
    {
        if (healthPoints > 0 && _currentHealth < _maxHealth)
        {
            _currentHealth += healthPoints;
        }
        else if (healthPoints < 0 && _currentHealth > 0 && !_isDamaged)
        {
            _animator.SetTrigger("hit");
            _currentHealth += healthPoints;
            _isDamaged = true;
            _tossableObject.Toss();
            Handheld.Vibrate();
        }
        HpChange.Invoke();
    } 
    
    public void Kill()
    {
        _currentHealth = 0;
    }
}
