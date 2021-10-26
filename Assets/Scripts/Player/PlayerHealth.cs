using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObjectTossed))]
public class PlayerHealth : MonoBehaviour
{
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public UnityEvent HpChange;

    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Player _player;
    private ObjectTossed _tossed;
    private bool _isDamaged = false;

    private void Start()
    {
        _tossed = GetComponent<ObjectTossed>();
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
            _player.Animator.SetTrigger("hit");
            _currentHealth += healthPoints;
            _isDamaged = true;
            _tossed.Toss();
        }
        HpChange.Invoke();
    }    
    
    public void Kill()
    {
        _currentHealth = 0;
    }
}
