using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<EnemyMovement> _enemies;
    [SerializeField] private List<Spawn> _spawns;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private int _maxEnemiesOnMap;
    private List<Spawn> _activeSpawns;

    private int _quantityEnemiesOnMap = 0;

    private void Awake()
    {
        _activeSpawns = new List<Spawn>();
    }

    private void Update()
    {
        if(_quantityEnemiesOnMap < _maxEnemiesOnMap)
            Spawn();

        CheckSpawns();

    }

    private void Spawn()
    {
        var spawn = _spawns[Random.Range(0, _spawns.Count - 1)];
        if (!spawn.IsOccupied)
        {
            var enemyTemplate = _enemies[Random.Range(0, _enemies.Count - 1)];
            var enemy = Instantiate(enemyTemplate, spawn.transform.position, Quaternion.identity, spawn.transform);
            spawn.Init(enemy);
            _activeSpawns.Add(spawn);
            _quantityEnemiesOnMap++;
        }
    }

    private void CheckSpawns()
    {
        var activeSpawn = _activeSpawns.FirstOrDefault(activeSpawn => !activeSpawn.Enemy.gameObject.activeInHierarchy);
        if (activeSpawn != null)
        {
            activeSpawn.Clear();
            _activeSpawns.Remove(activeSpawn);
            _quantityEnemiesOnMap--;
        }
    }
}
