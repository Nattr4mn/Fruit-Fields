using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Vision))]
public class RinoEnemy : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private float _pauseAfterCollision;
    [SerializeField] private GameObject _killZone;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Vision _vision;
    private bool _isRunning = false;
    private bool _isPause = false;

    void Update()
    {
        EnemyLogic();
    }

    public override void EnemyLogic()
    {
        if(!_isPause)
        {
            bool enemyVisible = _vision.DetectEnemy(transform.right) || _vision.DetectEnemy(-transform.right);

            if (enemyVisible)
            {
                Animator.SetBool("running", true);
                _killZone.SetActive(false);
                _isRunning = true;
            }

            if (_isRunning)
            {
                Rigidbody.velocity = transform.right * _speed;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        bool isHeadOnCollision = HeadOnCollision(collision.contacts);

        if (isHeadOnCollision && !_isPause)
        {
            _isRunning = false;
            Animator.SetBool("running", false);
            Animator.SetTrigger("hitWall");
            _killZone.SetActive(true);
            StartCoroutine(PauseAfterCollision());
            Rigidbody.velocity = Vector2.zero;
        }
    }

    private void CalculatingDirectionPoints(Vector2 direction, out Vector2 frontPoint, out Vector2 backPoint)
    {
        if (direction.x > 0)
        {
            backPoint = _collider.bounds.min;
            frontPoint = new Vector2(_collider.bounds.max.x, backPoint.y);
        }
        else
        {
            frontPoint = _collider.bounds.min;
            backPoint = new Vector2(_collider.bounds.max.x, frontPoint.y);
        }
    }

    private bool HeadOnCollision(ContactPoint2D[] contacts)
    {
        Vector2 frontPoint, backPoint;
        CalculatingDirectionPoints(transform.right, out frontPoint, out backPoint);

        foreach (var contact in contacts)
        {
            if (contact.point.y > frontPoint.y && Vector2.Distance(contact.point, frontPoint) < Vector2.Distance(contact.point, backPoint))
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator PauseAfterCollision()
    {
        _isPause = true;
        yield return new WaitForSeconds(_pauseAfterCollision);
        _isPause = false;
    }
}
