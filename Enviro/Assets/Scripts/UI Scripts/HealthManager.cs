using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider _healthSlider;
    
    public void SetMaxHealth(int maxHealth) // Setea vida máxima
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
    }

    public void SetHealth(int health) // se cambia la vida actual
    {
        _healthSlider.value = health;
    }
}
