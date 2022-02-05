using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fan : MonoBehaviour
{
    [SerializeField] private float _fanForce = 20f;
    [SerializeField] private float _pauseTime = 2f;
    [SerializeField] private float _pauseEverySeconds = 2f;
    private Animator _animator;
    private bool _isActive = true;
    private float _timer = 0f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if(_isActive && _timer >= _pauseEverySeconds)
        {
            StartCoroutine(Pause());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isActive && collision.TryGetComponent(out Player player))
        {
            player.Rigidbody.velocity = Vector2.up * _fanForce;
        }
    }

    private IEnumerator Pause()
    {
        _isActive = false;
        _animator.SetBool("active", _isActive);
        yield return new WaitForSeconds(_pauseTime);
        _timer = 0f;
        _isActive = true;
        _animator.SetBool("active", _isActive);
    }
}
