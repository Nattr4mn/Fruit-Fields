using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class KillZone : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    private Collider2D _collider;
    private bool _isDamaged = false;

    private void Start()
    {
        _enemyHealth?.EnemyDead.AddListener(OffKillZone);
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Tossable.Toss();
            if (!_isDamaged)
            {
                _isDamaged = true;
                _enemyHealth.HealthChange(-1);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _isDamaged = false;
        }
    }

    private void OnDestroy()
    {
        _enemyHealth?.EnemyDead.RemoveListener(OffKillZone);
    }

    private void OffKillZone() => gameObject.SetActive(false);
}
