using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangeAttack))]
[RequireComponent(typeof(Vision))]
[RequireComponent(typeof(EnemyMovement))]
public class TrunkEnemy : Enemy
{
    public float AngryTime => _angryTime;
    public EnemyMovement Movement => _movement;
    public IAttack Attack => _attack;

    [SerializeField] private float _angryTime;
    [SerializeField] private RangeAttack _attack;
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private Vision _vision;
    private bool _isAngry = false;

    private void Start()
    {
        transform.position = _movement.MovementPoints[0].position;
    }

    public override void EnemyLogic()
    {
        bool enemyVisible = _vision.DetectEnemy(-transform.right) || _vision.DetectEnemy(transform.right);

        if (enemyVisible)
        {
            _isAngry = true;
            Animator.SetBool("running", false);
            Attack.Attack();
        }
        else if (_isAngry)
        {
            StartCoroutine(Angry());
        }

        if (!_isAngry)
        {
            Movement.Move();
        }
    }

    private IEnumerator Angry()
    {
        float timer = 0f;
        while(timer <= AngryTime)
        {
            timer += Time.deltaTime;
            if (_vision.DetectEnemy(-transform.right) || _vision.DetectEnemy(transform.right))
            {
                yield break;
            }
            yield return null;
        }

        _isAngry = false;
    }
}
