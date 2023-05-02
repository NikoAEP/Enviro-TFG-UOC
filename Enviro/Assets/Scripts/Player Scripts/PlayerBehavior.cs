using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    [SerializeField] private HealthManager _healthManager; // se coge el manager de vida
    
    /* Sonidos de Efectos */
    [SerializeField] private AudioSource destroySFX;
    [SerializeField] private AudioSource damageSFX;
    [SerializeField] private AudioSource dieSFX;

    void Start()
    {
        anim = GetComponent<Animator>(); // se coge el componente del animador
        rb = GetComponent<Rigidbody2D>(); // se coge el rigid body del jugador
    }

    public void PlayerTakeDamage (int damage) // El jugador recibe daño
    {
        anim.Play("Player_Hit"); // se inicia la animación del jugador siendo dañado
        damageSFX.Play(); // se inicia el sonido de daño
        GameManager.instance._playerHealth.TakeDamage(damage); // se avisa al Game Manager que el jugador ha sido dañado
        _healthManager.SetHealth(GameManager.instance._playerHealth.Health); // se actualiza la vida a la vida actual del jugador
        print("Player Health: " + GameManager.instance._playerHealth.Health);

        if(GameManager.instance._playerHealth.Health <= 0) // si la vida del jugador es 0 o menos
        {
            dieSFX.Play(); // se inicia el sonido de muerte
            Die(); // se invoka el método de muerte 
        }
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; // se hace que el rigidbody sea estático para que no se pueda mover
        anim.Play("Player_Death"); // se incia la animación de muerte
        GameManager.instance.GameOver(); // se invoka el método de fin de juego en el Game Manager
    }
}
