using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
class Bullet : MonoBehaviour
{
    [SerializeField] private Transform _bullet;
    [SerializeField] private float _speed;
    private float _lifeDistance;
    private int _bulletDamage;

    public void Initialized(float lifeDistance, int bulletDamage)
    {
        _lifeDistance = lifeDistance;
        _bulletDamage = bulletDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            player.Kill();
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Shot(Vector3 startPosition, Vector3 direction)
    {
        _bullet.rotation = Quaternion.Euler(direction.normalized * 180f);
        StartCoroutine(BulletFlight(startPosition, direction));
    }

    private IEnumerator BulletFlight(Vector3 startPosition, Vector3 direction)
    {
        _bullet.position = startPosition;
        var endPosition = _bullet.position + (direction.normalized * _lifeDistance);

        while (_bullet.position != endPosition && _bullet.gameObject.activeSelf)
        {
            _bullet.position = Vector3.MoveTowards(_bullet.position, endPosition, _speed * Time.deltaTime);
            yield return null;
        }

        gameObject.SetActive(false);
    }

}
