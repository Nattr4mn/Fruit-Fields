using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    public bool LockJump = false;

    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxJumps = 2;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private ParticleSystem _jumpParticle;
    [SerializeField] private Transform _jumpParticlePostion;
    [SerializeField] private AudioSource _soundEffect;
    [SerializeField] private AudioClip _jumpSound;
    private List<ParticleSystem> _particlePool = new List<ParticleSystem>();
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _inAir = false;
    private int _jumpsCount = 0;

    public void Init(Animator animator, Rigidbody2D rigidbody)
    {
        _jumpsCount = _maxJumps;
        _animator = animator;
        _rigidbody = rigidbody;
    }

    public void Jump()
    {
        if(!LockJump)
        {
            if ((CheckGround() || _jumpsCount > 0) || (!CheckGround() && !_inAir))
            {
                _soundEffect.PlayOneShot(_jumpSound);
                _jumpsCount--;
                _animator.SetTrigger("jump");
                _rigidbody.velocity = Vector2.up * _jumpForce;
                PlayParticle();
            }
        }
        else
        {
            throw new System.Exception("Jump is lock!");
        }
    }

    private void PlayParticle()
    {
        var particle = _particlePool.FirstOrDefault(effect => effect.isStopped);
        if (particle == null)
        {
            var effect = Instantiate(_jumpParticle, _jumpParticlePostion.position, Quaternion.identity);
            _particlePool.Add(effect);
        }
        else
        {
            particle.transform.position = _jumpParticlePostion.position;
            particle.Play();
        }
    }

    private bool CheckGround()
    {
        var groundCheck = _groundChecker.CheckGround();
        if (groundCheck)
        {
            _jumpsCount = _maxJumps;
            _inAir = false;
            return true;
        }
        _inAir = true;
        return false;
    }
}
