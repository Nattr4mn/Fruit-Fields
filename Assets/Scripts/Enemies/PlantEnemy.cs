using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Vision))]
[RequireComponent(typeof(RangeAttack))]
public class PlantEnemy : Enemy
{
    public IAttack Attack => _attack;

    [SerializeField] private RangeAttack _attack;
    [SerializeField] private Vision _vision;
    void Update()
    {
        EnemyLogic();
    }

    public override void EnemyLogic()
    {
        bool enemyVisible = _vision.DetectEnemy(-transform.right) || _vision.DetectEnemy(transform.right);

        if (enemyVisible)
        {
            Attack.Attack();
        }
    }
}
