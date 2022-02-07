using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FireBlock : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _pauseTime = 2f;
    [SerializeField] private float _fireTime = 2f;
    private Animator _animator;
    private bool _dealsDamage = false;
    private float _timer = 0f;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (!_dealsDamage && _timer >= _pauseTime)
        {
            SetState(true);
        }
        else if (_dealsDamage && _timer >= _fireTime)
        {
            SetState(false);
        }
    }

    private void SetState(bool dealsDamage)
    {
        _timer = 0f;
        _animator.SetBool("active", dealsDamage);
        _dealsDamage = dealsDamage;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            if(_dealsDamage)
            {
                player.Kill();
            }
        }
    }
}
