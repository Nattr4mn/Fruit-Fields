using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _healthPointTamplate;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private int _maxHealthPointCount = 3;
    private List<GameObject> _healthPointPool = new List<GameObject>();
    private int _currentHealthPointCount = 0;

    private void Start()
    {
        foreach(var point in _spawnPoints)
        {
            var hp = Instantiate(_healthPointTamplate, point.position, Quaternion.identity, point);
            hp.SetActive(false);
            _healthPointPool.Add(hp);
        }
    }

    private void Update()
    {
        if(_currentHealthPointCount < _maxHealthPointCount)
        {
            var hpIndex = Random.Range(0, _healthPointPool.Count - 1);
            if(!_healthPointPool[hpIndex].activeSelf)
            {
                _healthPointPool[hpIndex].SetActive(true);
                _currentHealthPointCount++;
            }
        }
    }
}
