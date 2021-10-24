using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Thrown))]
public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    public UnityEvent HpChange;

    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Player _player;
    private Thrown _thrown;

    private void Start()
    {
        _thrown = GetComponent<Thrown>();
    }

    public void HealthChange(float healthPoints)
    {
        if (healthPoints > 0 && _currentHealth < _maxHealth)
        {
            _currentHealth += healthPoints;
        }
        else if (healthPoints < 0 && _currentHealth > 0)
        {
            _player.Animator.SetTrigger("hit");
            _thrown.Throw();
        }
        HpChange.Invoke();
    }    
    
    public void Kill()
    {
        _currentHealth = 0;
    }
}
