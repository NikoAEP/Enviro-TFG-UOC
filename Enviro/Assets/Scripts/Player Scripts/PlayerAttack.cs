using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    [SerializeField] private int attackDamage;
    private PlayerMovement playerMovement;

    void Start()
    {
        attackDamage = 5;
        playerMovement = transform.parent.gameObject.GetComponent<PlayerMovement>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision) // cuando entra en colisión con un enemigo
    {
        if(collision.gameObject.tag == "Weak Point") // tiene que dar en el "punto débil" del enemigo
            {
                var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>(); // se coge el componente de vida del enemigo
                var enemyMovement = collision.gameObject.GetComponent<EnemyMovement>(); // se coge el componente de movimiento del enemigo              
                enemyMovement.isBeingHit = true; // se avisa que le está dando
                enemyHealth.receiveDamage(attackDamage); // el enemigo recibe el daño del jugador
                playerMovement.KBCounter = playerMovement.KBTotalTime; // resetea el contador de knockback
            if(collision.transform.position.x <= transform.position.x) // si el jugador está a la izquierda del enemigo
            {
                playerMovement.knockFromRight = false; // el jugador recibe knockback de la derecha
            }
            if(collision.transform.position.x > transform.position.x) // si el jugador está a la derecha del enemigo
            {
                playerMovement.knockFromRight = true; // el jugador recibe knockback de la izquierda
            }
            
            }
    }

    private void OnCollisionExit2D(Collision2D collision) // chequea cuando sale de la colisión
    {
        if(collision.gameObject.tag == "Weak Point")
            {
                var enemyMovement = collision.gameObject.GetComponent<EnemyMovement>();
                enemyMovement.isBeingHit = false; // el enemigo ya no está siendo dañado
            }
    }
}
