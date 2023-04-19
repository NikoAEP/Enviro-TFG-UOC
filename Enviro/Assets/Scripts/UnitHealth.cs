using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    // Campos
    int _currentHealth;
    int _currentMaxHealth;
    
    // Propiedades
    public int Health
    {
        get
        {
            return _currentHealth;
        } 
        set
        {
            _currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        } 
        set
        {
            _currentMaxHealth = value;
        }
    }

    // Constructor
    public UnitHealth(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    // Métodos
    public void TakeDamage(int damageAmount)
    {
        if(_currentHealth > 0)
        {
            _currentHealth -= damageAmount;
        }
        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
        }
    }
}
