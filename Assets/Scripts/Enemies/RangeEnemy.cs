using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangeAttack))]
[RequireComponent(typeof(Vision))]
public class RangeEnemy : AbstractEnemy
{
    [Header("Vision settings")]
    [SerializeField] private List<Vector3> _visionDirections;
    [SerializeField] private float _visionDistance;
    [SerializeField] private LayerMask _triggerMask;

    [Header("Attack settings")]
    [SerializeField] private float _attackDistance;
    [SerializeField] private Vector3 _attackDirection;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private Bullet _bulletTemplate;

    private RangeAttack _attack;
    private Vision _vision;

    public IReadOnlyList<Vector3> VisionDirections => _visionDirections;
    public Vision Vision => _vision;
    public IAttack Attack => _attack;

    protected override void Awake()
    {
        base.Awake();
        _attack = GetComponent<RangeAttack>();
        _attack.Init(_attackDistance, _attackDirection, _bulletStartPosition, Animator, _bulletTemplate);
        _vision = GetComponent<Vision>();
        _vision.Init(_visionDistance, _triggerMask);
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
