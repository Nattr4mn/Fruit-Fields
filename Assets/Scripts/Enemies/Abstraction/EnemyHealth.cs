using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Killable))]
public class EnemyHealth : MonoBehaviour
{
    public UnityEvent<float, float> HPChange;
    public UnityEvent Death;

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

    public void HealthChange()
    {
        _animator.SetTrigger("hit");
        _currentHealth -= 1;
        if (_currentHealth <= 0)
        {
            Death?.Invoke();
            _killable.Kill();
        }


        HPChange?.Invoke(_currentHealth, _maxHealth);
    }
}
