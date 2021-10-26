using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private GameObject _healthTemplate;
    [SerializeField] private Transform _container;
    private List<GameObject> _healthPointPool = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < _playerHealth.MaxHealth; i++)
        {
            var healthObject = Instantiate(_healthTemplate, _container);
            if(i > _playerHealth.CurrentHealth - 1)
            {
                healthObject.SetActive(false);
            }
            _healthPointPool.Add(healthObject);
        }
    }

    public void HealthBarRedrawing()
    {
        int deltaHealth = (_playerHealth.MaxHealth - 1) - (_playerHealth.CurrentHealth - 1);
        int healthPointCount = _playerHealth.MaxHealth - 1;
        for (int i = healthPointCount; i <= healthPointCount - deltaHealth; i++)
        {
            _healthPointPool[i].SetActive(false);
        }
    }
}
