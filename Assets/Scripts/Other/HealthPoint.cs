using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField] private int _healthPoint = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            if(player.Health.CurrentHealth < player.Health.MaxHealth)
            {
                player.Health.HealthChange(_healthPoint);
                gameObject.SetActive(false);
            }
        }
    }
}
