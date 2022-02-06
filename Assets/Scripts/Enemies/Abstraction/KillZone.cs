using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private EnemyHealth _hp;
    private bool _isDamaged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            player.Tossable.Toss();
            if (!_isDamaged)
            {
                _isDamaged = true;
                _hp.HealthChange();
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
}
