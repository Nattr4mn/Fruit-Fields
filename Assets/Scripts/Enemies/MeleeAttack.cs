using System;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public event Action AttackEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Kill();
            AttackEvent?.Invoke();
        }
    }
}
