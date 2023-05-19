using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    // Campos
    int _currentHealth; // vida actual
    int _currentMaxHealth; // vida máxima
    
    // Propiedades
    public int Health
    {
        get
        {
            return _currentHealth; // retorna la vida actual
        } 
        set
        {
            _currentHealth = value; // se setea la vida actual
        }
    }

    public int MaxHealth
    {
        get
        {
            return _currentMaxHealth; // retorna la vida máxima
        } 
        set
        {
            _currentMaxHealth = value; // se setea la vida máxima
        }
    }

    // Constructor
    public UnitHealth(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    // Métodos
    public void TakeDamage(int damageAmount) // reciba daño
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
