using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;

    public void UpdateSlider(float currentHealth, float maxHealth)
    {
        _hpSlider.value = currentHealth / maxHealth;
    }
}
