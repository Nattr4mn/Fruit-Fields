using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private GameObject _healthTemplate;
    [SerializeField] private Transform _container;
    private List<GameObject> _healthObjectPool = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < _playerHealth.MaxHealth; i++)
        {
            var healthObject = Instantiate(_healthTemplate, _container);
            if(i > _playerHealth.CurrentHealth)
            {
                healthObject.SetActive(false);
            }
            _healthObjectPool.Add(healthObject);
        }
    }

    public void HealthBarRedrawing()
    {
        var deltaHealth = _playerHealth.MaxHealth - _playerHealth.CurrentHealth;
        var healthObjectCount = _healthObjectPool.Count - 1;
        for (int i = healthObjectCount; i < healthObjectCount - deltaHealth; i++)
        {
            _healthObjectPool[i].SetActive(false);
        }
    }
}
