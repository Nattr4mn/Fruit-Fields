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
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Animator _animator;
    private bool _isAttack = false;
    private List<Bullet> _bulletsPool = new List<Bullet>();

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
        Bullet bullet = null;

        if(_bulletContainer.childCount > 0)
        {
            bullet = _bulletsPool.FirstOrDefault(existBullet => existBullet.gameObject.activeInHierarchy == false);
        }

        if (bullet == null)
        {
            var newBullet = Instantiate(_bulletTemplate, _bulletStartPosition.position, Quaternion.identity, _bulletContainer);
            newBullet.Initialized(_attackDistance, _damage);
            newBullet.Shot(_bulletStartPosition.position, transform.right);
            _bulletsPool.Add(newBullet);
        }
        else
        {
            bullet.gameObject.SetActive(true);
            bullet.Shot(_bulletStartPosition.position, transform.right);
        }

        _isAttack = false;
    }
}
