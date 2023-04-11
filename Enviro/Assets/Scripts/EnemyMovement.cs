using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Transform rb; // creamos variable del Rigidbody
    private BoxCollider2D coll; // creamos variable del Colisionador
    private SpriteRenderer sprite; // creamos variable del sprite de animación
    private Animator anim; // creamos variable animador

    [SerializeField] private float horizontalSpeed = 5f; // creamos variable serializada de la velocidad de movimiento
    private float dirX = 1f; // creamos variable de dirección en el eje x
    private float maxX = 4f;
    private float minX = -4f;
    
    void Start()
    {
        rb = GetComponent<Transform>(); // asignamos el rigidbody a la variable
        coll = GetComponent<BoxCollider2D>(); // asignamos el colisionador a la variable
        sprite = GetComponent<SpriteRenderer>(); // asignamos el sprite al variable
        anim = GetComponent<Animator>(); // asignamos el animador a la variable
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.x == maxX || rb.position.x == minX)
        {
            dirX *= -1; 
        }

        if((rb.position.x < maxX) && (dirX > 0f))
        {
            rb.Translate(Vector2.right * horizontalSpeed * Time.deltaTime);
        }
        if((rb.position.x > minX) && (dirX < 0f))
        {
            rb.Translate(-Vector2.right * horizontalSpeed * Time.deltaTime);
        }

        //UpdateAnimationState();    // actualizamos el estado de animación 
    }

    /*private void UpdateAnimationState() // cambio de estados de animación
    {
        MovementState state;

        if (dirX > 0f) // si la dirección es positiva, nos movemos a la derecha
        {
            state = MovementState.moving;
            sprite.flipX = false;
        }
        else if (dirX < 0f) // si la dirección es negativa, nos movemos a la izquierda
        {
            state = MovementState.moving;
            sprite.flipX = true;
        }
        
        anim.SetInteger("state", (int)state); // le pasamos la posición del estado al Animator
    }*/
}
