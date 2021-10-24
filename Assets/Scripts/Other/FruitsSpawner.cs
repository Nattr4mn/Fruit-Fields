using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{
    public int CollectedFruits => _collectedFruits;
    public int TotalFruit => _spawnPoints.Count;

    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Fruit> _fruits;
    [SerializeField] private Player _player;
    [SerializeField] private AudioClip _fruitSound;
    [SerializeField] private AudioSource _effectsSource;
    private int _collectedFruits = 0;

    private void Start()
    {
        foreach(var spawnPoint in _spawnPoints)
        {
            var randomFruit = _fruits[Random.Range(0, _fruits.Count - 1)];
            var fruit = Instantiate(randomFruit, spawnPoint.position, Quaternion.identity, spawnPoint);
            fruit.Initialized(_player);
            fruit.FruitCollected += FruitIsCollected;
        }
    }

    public void FruitIsCollected()
    {
        _collectedFruits++;
        _effectsSource.PlayOneShot(_fruitSound);
    }
}
