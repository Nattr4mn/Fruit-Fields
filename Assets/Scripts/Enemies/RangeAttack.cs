using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RangeAttack : MonoBehaviour, IAttack
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private Transform _bulletContainer;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private GameObject _bulletTemplate;
    [SerializeField] private Animator _animator;
    private bool _isAttack = false;
    private List<GameObject> _bulletsPool = new List<GameObject>();

    public void Attack()
    {
        if(!_isAttack)
        {
            _animator.SetTrigger("attack");
            _isAttack = true;
        }
    }

    public void Shot()
    {
        GameObject bullet = null;

        if(_bulletContainer.childCount > 0)
        {
            bullet = _bulletsPool.FirstOrDefault(existBullet => existBullet.activeInHierarchy == false);
        }

        if (bullet == null)
        {
            var newBullet = Instantiate(_bulletTemplate, _bulletStartPosition.position, Quaternion.identity, _bulletContainer);
            newBullet.GetComponent<Bullet>().Initialized(_attackDistance, _damage);
            newBullet.GetComponent<Bullet>().Shot(_bulletStartPosition.position, transform.right);
            _bulletsPool.Add(newBullet);
        }
        else
        {
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().Shot(_bulletStartPosition.position, transform.right);
        }

        _isAttack = false;
    }
}
