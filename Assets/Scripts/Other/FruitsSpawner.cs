using System;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{
    public event Action CollectionComplete;
    [SerializeField] private List<Fruit> _fruits;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Fruit> _stars;
    [SerializeField] private int  _maxStars;
    [SerializeField] private AudioClip _fruitSoundClip;
    [SerializeField] private AudioSource _soundEffectSource;
    private int _totalFruits;
    private int _collectedFruits;
    private int _totalStars;
    private int _collectedStars;

    public int CollectedFruits => _collectedFruits;
    public int TotalFruits => _totalFruits;
    public int CollectedStars => _collectedStars;
    public int TotalStars => _totalStars;

    private void OnValidate()
    {
        if(_stars?.Count > _maxStars)
        {
            _stars = _stars.GetRange(0, _maxStars);
        }
    }

    private void Awake()
    {
        if (_stars != null)
        {
            _stars.ForEach(star => star.FruitCollected += StarIsCollected);
            _totalStars = _stars.Count;
        }

        _totalFruits = _spawnPoints.Count;

        foreach (var spawnPoint in _spawnPoints)
        {
            var randomFruit = _fruits[UnityEngine.Random.Range(0, _fruits.Count - 1)];
            var fruit = Instantiate(randomFruit, spawnPoint.position, Quaternion.identity, spawnPoint);
            fruit.FruitCollected += FruitIsCollected;
        }
    }

    private void FruitIsCollected()
    {
        _collectedFruits++;
        _soundEffectSource.PlayOneShot(_fruitSoundClip);

        if(_collectedFruits == _totalFruits)
            CollectionComplete?.Invoke();
    }

    private void StarIsCollected()
    {
        _collectedStars++;
        _soundEffectSource.PlayOneShot(_fruitSoundClip);
    }
}
