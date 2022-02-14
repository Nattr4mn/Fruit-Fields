using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Vision))]
public class RinoEnemy : AbstractEnemy
{
    [SerializeField] private AudioClip _run;

    [Header("Other settings")]
    [SerializeField] private float _speed;
    [SerializeField] private float _pauseAfterCollision;
    [SerializeField] private GameObject _killZone;
    [SerializeField] private int _wallMask = 12;

    [Header("Vision settings")]
    [SerializeField] private Vision _vision;
    [SerializeField] private float _visionDistance;
    [SerializeField] private LayerMask _triggerMask;
    private bool _isRunning = false;
    private bool _isPause = false;

    protected override void Awake()
    {
        base.Awake();
        _vision = GetComponent<Vision>();
        _vision.Init(_visionDistance, _triggerMask);
    }

    public override void EnemyLogic()
    {
        if(!_isPause)
        {
            bool enemyVisible = !_isRunning && (_vision.DetectEnemy(transform.right) || _vision.DetectEnemy(-transform.right));

            if (enemyVisible)
            {
                Run();
            }

            if (_isRunning)
            {
                Rigidbody.velocity = transform.right * _speed;
            }
        }
    }

    private void Run()
    {
        Animator.SetBool("running", true);
        AudioSource.clip = _run;
        AudioSource.Play();
        _killZone.SetActive(false);
        _isRunning = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _wallMask && !_isPause)
        {
            _isRunning = false;
            Animator.SetBool("running", false);
            Animator.SetTrigger("hitWall");
            AudioSource.Stop();
            AudioSource.PlayOneShot(HitClip);
            _killZone.SetActive(true);
            StartCoroutine(PauseAfterCollision());
            Rigidbody.velocity = Vector2.zero;
        }
    }

    private IEnumerator PauseAfterCollision()
    {
        _isPause = true;
        yield return new WaitForSeconds(_pauseAfterCollision);
        _isPause = false;
        Run();
        if (transform.rotation.y == 0)
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
