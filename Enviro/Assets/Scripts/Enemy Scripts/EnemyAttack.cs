using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyType type;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           var playerMovement = collision.gameObject.GetComponent<PlayerMovement>(); // coge el componente de movimiento del jugador
           playerMovement.KBCounter = playerMovement.KBTotalTime; // resetea el contador de knockback
           if(collision.transform.position.x <= transform.position.x) // si el jugador está a la izquierda del enemigo
           {
                playerMovement.knockFromRight = true; // el jugador recibe knockback de la derecha
           }
           if(collision.transform.position.x > transform.position.x) // si el jugador está a la derecha del enemigo
           {
                playerMovement.knockFromRight = false; // el jugador recibe knockback de la izquierda
           }
           collision.gameObject.GetComponent<PlayerBehavior>().PlayerTakeDamage(type.attackDamage); // daña al jugador 
        }   
    }
}
