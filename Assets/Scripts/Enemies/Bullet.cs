using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform _bullet;
    [SerializeField] private float _speed;
    private float _lifeDistance;

    public void Init(float lifeDistance)
    {
        _lifeDistance = lifeDistance;
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
        if(direction.x > 0)
            _bullet.rotation = Quaternion.Euler(0f, 180f, 0f);
        else
            _bullet.rotation = Quaternion.Euler(0f, 0f, 0f);
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
