using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangeAttack))]
[RequireComponent(typeof(Vision))]
public class RangeEnemy : AbstractEnemy
{
    public IReadOnlyList<Vector3> VisionDirections => _visionDirections;
    public Vision Vision => _vision;
    public IAttack Attack => _attack;

    [SerializeField] private List<Vector3> _visionDirections;
    [SerializeField] private Vision _vision;
    private RangeAttack _attack;

    protected virtual void Start()
    {
        _attack = GetComponent<RangeAttack>();
        _vision = GetComponent<Vision>();
    }

    public override void EnemyLogic()
    {
        if (TryFindEnemy())
        {
            Attack.Attack();
        }
    }

    public bool TryFindEnemy()
    {
        foreach (var direction in VisionDirections)
        {
            if (_vision.DetectEnemy(direction) == true)
            {
                return true;
            }
        }

        return false;
    }
}
