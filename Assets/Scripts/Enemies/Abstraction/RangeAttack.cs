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
        Bullet bullet = GetFreeBullet();

        if (bullet == null)
            _bulletsPool.Add(CreateNewBullet());
        else
            LaunchBullet(bullet);

        _isAttack = false;
    }

    private void LaunchBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.Shot(_bulletStartPosition.position, transform.right);
    }

    private Bullet CreateNewBullet()
    {
        var newBullet = Instantiate(_bulletTemplate, _bulletStartPosition.position, Quaternion.identity, _bulletContainer);
        newBullet.Initialized(_attackDistance, _damage);
        newBullet.Shot(_bulletStartPosition.position, transform.right);
        return newBullet;
    }

    private Bullet GetFreeBullet()
    {
        return _bulletsPool.FirstOrDefault(existBullet => existBullet.gameObject.activeInHierarchy == false);
    }
}
