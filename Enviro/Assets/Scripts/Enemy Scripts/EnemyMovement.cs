using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";

    Rigidbody2D rb; // creamos variable del Rigidbody
    
    [SerializeField] Transform castPos; // el objeto desde donde se hace un raycast para chequear muros y huecos
    [SerializeField] float baseCastDist; // la distancia del raycast
    [SerializeField] private float horizontalSpeed = 5f; // creamos variable serializada de la velocidad de movimiento
    
    string facingDirection; // la dirección en la que mira el enemigo
    Vector3 baseScale; // escala base

    public bool isBeingHit; // si está siendo dañado o no

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // asignamos el rigidbody a la variable
        facingDirection = RIGHT; // dirección
        baseScale = transform.localScale; // escala base del enemigo
        isBeingHit = false; // no está siendo dañado
    }

    private void FixedUpdate()
    {
        if(!isBeingHit) // mientras no esté siendo dañado
        {
            rb.bodyType = RigidbodyType2D.Kinematic; // el rigidbody es kinemático 
            float vX = horizontalSpeed;  // la velocidad en el eje x
            if(facingDirection == LEFT) // si se mueve a la izquierda
            {
                vX = -horizontalSpeed; // la velocidad es la que se haya indicado pero en negativo
            } 

            rb.velocity = new Vector2(vX, rb.velocity.y); // se mueve el enemigo

            if(isHittingWall() || isNearEdge()) // si está tocando una pared o un borde
            {
                if(facingDirection == LEFT) // si estaba moviéndose hacia la izquierda
                {
                    changeFacingDirection(RIGHT); // cambia de sentido a la derecha
                }
                else
                {
                    changeFacingDirection(LEFT); // si no, cambia de sentido a la izquierda
                }
            }
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Static; // si está siendo dañado, cambia el rigidbody a estático
        }
        
    }

    private void changeFacingDirection(string newDirection) // se cambia de dirección 
    {
        Vector3 newScale = baseScale; // se usa una variable temporal para cambiar la escala del jugador
        if(newDirection == LEFT) // si la dirección es izquierda
        {
            newScale.x = -baseScale.x; // la escala en x se hace negativa
        }
        else
        {
            newScale.x = baseScale.x; // si no, la escala en x se hace positiva
        }

        transform.localScale = newScale; // la escala local es la nueva escala
        facingDirection = newDirection; // la dirección en la que se está moviendo es la nueva dirección
    }

    private bool isHittingWall() // méotdo que revisa si está tocando una pared
    {
        bool val = false;

        float castDist = baseCastDist; // la distancia del cast es la definida 

        // define distancia de cast para izq. y der.
        if(facingDirection == LEFT)
        {
            castDist = -baseCastDist;
        }
        else
        {
            castDist = baseCastDist;
        }

        // determinar el destino según la distancia del cast
        Vector3 targetPos = castPos.position;
        targetPos.x += castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.blue);
        // si el cast toca algo que esté en la capa de "suelo"
        if(Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = true; // está tocando suelo o pared
        }
        else
        {
            val = false; // no está tocando suelo o pared
        }

        return val;
    }

    private bool isNearEdge() // método que revisa si está cerca de un borde
    {
        bool val = true;

        float castDist = baseCastDist;

        // determinar el destino según la distancia del cast
        Vector3 targetPos = castPos.position;
        targetPos.y -= castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.red);
        // si el cast toca algo que esté en la capa de "suelo"
        if(Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = false; // está tocando un hueco
        }
        else
        {
            val = true; // no está tocando hueco
        }

        return val;
    }

}
