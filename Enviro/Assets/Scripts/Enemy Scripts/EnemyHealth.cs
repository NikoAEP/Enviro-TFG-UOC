using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim; // se define la variable del Animador 
    [SerializeField] private EnemyType type; // se coge el tipo de enemifo
    [SerializeField] private AudioSource destroySFX; // audio de destrucción del enemigo
    [SerializeField] private AudioSource dieSFX; // audio de muerte del enemigo

    private int maxHealth; // la vida máxima
    private int currentHealth; // la vida actual
    
    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>(); // se coge el componente del Animador
        maxHealth = type.health; // la vida máxima será la vida máxima según el tipo de enemigo
        currentHealth = maxHealth; // inicialmente, la vida actual es la máxima
    }

    public void receiveDamage(int damage) // Método para recibir daño
    {
        anim.Play("Suraba_Hit"); // se inicia la animación
        currentHealth -= damage; // se recibe el daño
        print("enemy health: " + currentHealth);
        if (currentHealth <= 0) // si la vida actual es menor o igual a 0
            {
                currentHealth = 0; // la vida actual es 0
                GameManager.instance.EnemyDestroyed(type.value); // se avisa al GameManager que se ha destruido un enemigo
                destroySFX.Play(); // se inicia el audio de destrucción
                anim.Play("Suraba_Death"); // se incia la animación
                Invoke("Die", 0.6f); // se invoca la muerte después de la animación
            }
    }

    private void Die()
    {       
        dieSFX.Play(); // se inicia el audio de muerte 
        Destroy(gameObject);  // se destruye el enemigo 
    }

}
