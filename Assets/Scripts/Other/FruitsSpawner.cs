using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{
    public int CollectedFruits => _collectedFruits;
    public int TotalFruit => _totalFruits;

    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Fruit> _fruits;
    [SerializeField] private Fruit _star;
    [SerializeField] private AudioClip _fruitSoundClip;
    [SerializeField] private AudioSource _soundEffectSource;
    private int _totalFruits = 0;
    private int _collectedFruits = 0;

    private void Start()
    {
        if (_star != null)
        {
            _star.FruitCollected += StarIsCollected;
            _totalFruits = _spawnPoints.Count + (int)(_spawnPoints.Count * 0.15f);
        }
        else
        {
            _totalFruits = _spawnPoints.Count;
        }

        foreach (var spawnPoint in _spawnPoints)
        {
            var randomFruit = _fruits[Random.Range(0, _fruits.Count - 1)];
            var fruit = Instantiate(randomFruit, spawnPoint.position, Quaternion.identity, spawnPoint);
            fruit.FruitCollected += FruitIsCollected;
        }
    }

    private void FruitIsCollected()
    {
        _collectedFruits++;
        _soundEffectSource.PlayOneShot(_fruitSoundClip);
    }

    private void StarIsCollected()
    {
        _collectedFruits+= (int)(_spawnPoints.Count * 0.15f);
        _soundEffectSource.PlayOneShot(_fruitSoundClip);
    }
}
