using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; // creamos variable del Rigidbody
    private BoxCollider2D coll; // creamos variable del Colisionador
    private SpriteRenderer sprite; // creamos variable del sprite de animación
    private Animator anim; // creamos variable animador

    [SerializeField] private LayerMask jumpableGround; // creamos variable serializada de la capa de Ground
    [SerializeField] private float jumpForce = 14f; // creamos variable serializada de la fuerza de salto
    [SerializeField] private float horizontalSpeed = 7f; // creamos variable serializada de la velocidad de movimiento

    private float dirX = 0f; // creamos variable de dirección en el eje x

    private enum MovementState { idle, running, jumping, falling }; // listado de los diferentes estados

    [SerializeField] private AudioSource jumpSFX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // asignamos el rigidbody a la variable
        coll = GetComponent<BoxCollider2D>(); // asignamos el colisionador a la variable
        sprite = GetComponent<SpriteRenderer>(); // asignamos el sprite al variable
        anim = GetComponent<Animator>(); // asignamos el animador a la variable
        
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal"); // asignamos valor del eje X en función de la tecla presionada
        rb.velocity = new Vector2(dirX * horizontalSpeed, rb.velocity.y); // la velocidad horizontal variará en función de la dirección, la velocidad vertical será la acutal

        if (Input.GetButtonDown("Jump") && OnGround()) // si presionamos la tecla de salto y estamos en el suelo
        {
            jumpSFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // si se salta, se aplica una fuerza vertical y se mantiene la velocidad horizontal
        }

        UpdateAnimationState();    // actualizamos el estado de animación    
    }

    private void UpdateAnimationState() // cambio de estados de animación
    {
        MovementState state;

        if (dirX > 0f) // si la dirección es positiva, nos movemos a la derecha
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f) // si la dirección es negativa, nos movemos a la izquierda
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else // no se está moviendo en el eje x
        {
            state = MovementState.idle; // estamos quietos
        }

        if (rb.velocity.y > 0.1f) // si la velocidad vertical es positiva, estamos saltando
        {
            state = MovementState.jumping;
        }  
        else if (rb.velocity.y < -0.1f) // si la velocidad vertical es positiva, estamos cayendo
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state); // le pasamos la posición del estado al Animator
    }

    private bool OnGround() // revisamos si está tocando el suelo
    {
        // cogemos el centro del colisionador y revisamos si hay solapamiento con todo aquello que sea el "suelo"
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
