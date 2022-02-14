using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(MeleeAttack))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyHealth))]
public abstract class AbstractEnemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private MeleeAttack _attack;
    [SerializeField] private int _healthPoint;

    [Header("Audio settings")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _hit;

    public Animator Animator => _animator;
    public Rigidbody2D Rigidbody => _rigidbody;
    public Collider2D Collider => _collider;
    public EnemyHealth Health => _health;
    public MeleeAttack Attack => _attack;
    public AudioSource AudioSource => _audioSource;
    public AudioClip HitClip => _hit;

    protected virtual void Awake()
    {
        if( _animator == null )
            _animator = GetComponent<Animator>();
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody2D>();
        if (_collider == null)
            _collider = GetComponent<Collider2D>();
        if (_health == null)
            _health = GetComponent<EnemyHealth>();
        if (_attack == null)
            _attack = GetComponent<MeleeAttack>();

        _health.Init(_animator, _collider, _rigidbody, _healthPoint);
        _health.InitSound(_audioSource, _hit);
        _health.EnemyDead.AddListener(EnemyDisable);
    }

    private void Update()
    {
        EnemyLogic();
    }

    public abstract void EnemyLogic();
    public void EnemyDisable() => enabled = false;

    private void OnDestroy()
    {
        _health.EnemyDead.RemoveListener(EnemyDisable);
    }
}
