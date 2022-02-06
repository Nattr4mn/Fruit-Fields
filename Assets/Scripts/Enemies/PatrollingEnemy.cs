using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class PatrollingEnemy : AbstractEnemy
{
    private EnemyMovement _movement;

    private void Start()
    {
        _movement = GetComponent<EnemyMovement>();
    }

    public override void EnemyLogic()
    {
        if(_movement.IsStoped)
            Animator.SetBool("running", false);
        else
            Animator.SetBool("running", true);

        _movement.Move();
    }
}
