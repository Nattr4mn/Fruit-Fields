using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private Transform _rockTemplate;
    [SerializeField] private float _timeBtwSpawn = 5f;
    private IEnumerator _spawn;

    private void Start()
    {
        if(_leftPoint.position.x > _rightPoint.position.x)
        {
            var pos = _leftPoint;
            _leftPoint = _rightPoint;
            _rightPoint = pos;
        }

        _spawn = Spawn();
        StartCoroutine(_spawn);
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(_timeBtwSpawn);
            var positionX = Random.Range(_leftPoint.position.x, _rightPoint.position.x);
            var newPosition = _leftPoint.position;
            newPosition.x = positionX;
            Instantiate(_rockTemplate, newPosition, Quaternion.identity, transform);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(_spawn);
    }
}
