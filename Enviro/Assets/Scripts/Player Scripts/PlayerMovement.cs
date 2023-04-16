using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";

    private Rigidbody2D rb; // creamos variable del Rigidbody
    private BoxCollider2D coll; // creamos variable del Colisionador
    private Animator anim; // creamos variable animador

    [SerializeField] private LayerMask jumpableGround; // creamos variable serializada de la capa de Ground
    [SerializeField] private Transform feetPosition; 
    [SerializeField] private float groundCheckCircle; 
    private bool isGrounded;
    [SerializeField] private float jumpForce = 14f; // creamos variable serializada de la fuerza de salto

    [SerializeField] private float horizontalSpeed = 7f; // creamos variable serializada de la velocidad de movimiento
    string facingDirection;
    Vector3 baseScale; 

    private float dirX = 0f; // creamos variable de dirección en el eje x

    private enum MovementState { idle, running, jumping, falling }; // listado de los diferentes estados

    [SerializeField] private AudioSource jumpSFX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // asignamos el rigidbody a la variable
        coll = feetPosition.GetComponent<BoxCollider2D>(); // asignamos el colisionador a la variable
        anim = GetComponent<Animator>(); // asignamos el animador a la variable
        facingDirection = RIGHT;
        baseScale = transform.localScale;
        
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, jumpableGround);
        dirX = Input.GetAxis("Horizontal"); // asignamos valor del eje X en función de la tecla presionada
                       
        if (Input.GetButtonDown("Jump") && isGrounded) // si presionamos la tecla de salto y estamos en el suelo
        {
            jumpSFX.Play();
            rb.velocity = Vector2.up * jumpForce; // si se salta, se aplica una fuerza vertical y se mantiene la velocidad horizontal
        }  
        UpdateAnimationState();    // actualizamos el estado de animación
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * horizontalSpeed, rb.velocity.y); // la velocidad horizontal variará en función de la dirección, la velocidad vertical será la acutal          
    }

    private void UpdateAnimationState() // cambio de estados de animación
    {
        MovementState state;

        if (dirX > 0f) // si la dirección es positiva, nos movemos a la derecha
        {
            state = MovementState.running;
            changeFacingDirection(RIGHT);
        }
        else if (dirX < 0f) // si la dirección es negativa, nos movemos a la izquierda
        {
            state = MovementState.running;
            changeFacingDirection(LEFT);
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

    private void changeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;
        if(newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;
        facingDirection = newDirection;
    }
}