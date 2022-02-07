using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RangeAttack : MonoBehaviour, IAttack
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private Vector3 _attackDirection;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private Animator _animator;
    [SerializeField] private Bullet _bulletTemplate;
    private Transform _bulletContainer;
    private bool _isAttack = false;
    private List<Bullet> _bulletsPool = new List<Bullet>();

    private void Awake()
    {
        GameObject gameObj = new GameObject();
        gameObj.name = "Bullet container";
        _bulletContainer = gameObj.transform;
    }

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
            BulletLaunch(bullet);

        _isAttack = false;
    }

    private void BulletLaunch(Bullet bullet)
    {
        var attackDirection = transform.TransformDirection(_attackDirection);
        bullet.gameObject.SetActive(true);
        bullet.Shot(_bulletStartPosition.position, attackDirection);
    }

    private Bullet CreateNewBullet()
    {
        var newBullet = Instantiate(_bulletTemplate, _bulletStartPosition.position, Quaternion.identity, _bulletContainer);
        newBullet.Initialized(_attackDistance, _damage);
        BulletLaunch(newBullet);
        return newBullet;
    }

    private Bullet GetFreeBullet()
    {
        return _bulletsPool.FirstOrDefault(existBullet => existBullet.gameObject.activeInHierarchy == false);
    }
}
