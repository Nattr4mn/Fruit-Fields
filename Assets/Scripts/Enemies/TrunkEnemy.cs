using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class TrunkEnemy : RangeEnemy
{
    [SerializeField] private float _angryTime;
    private EnemyMovement _movement;
    private bool _isAngry = false;

    protected override void Start()
    {
        base.Start();
        _movement = GetComponent<EnemyMovement>();
    }

    public override void EnemyLogic()
    {
        if (TryFindEnemy())
        {
            AttackEnemy();
        }
        else if (_isAngry)
        {
            StartCoroutine(Angry());
        }

        if (!_isAngry)
        {
            Move();
        }
    }

    private void AttackEnemy()
    {
        _isAngry = true;
        Animator.SetBool("running", false);
        Attack.Attack();
    }

    private void Move()
    {
        if (_movement.IsStoped)
            Animator.SetBool("running", false);
        else
            Animator.SetBool("running", true);

        _movement.Move();
    }

    private IEnumerator Angry()
    {
        float timer = 0f;
        while (timer <= _angryTime)
        {
            timer += Time.deltaTime;
            if (TryFindEnemy())
            {
                yield break;
            }
            yield return null;
        }

        _isAngry = false;
    }
}
