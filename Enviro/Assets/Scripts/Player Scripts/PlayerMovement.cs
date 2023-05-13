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
    [SerializeField] private Transform feet; // el transform de los pies del jugador
    [SerializeField] private float jumpForce; // creamos variable serializada de la fuerza de salto
    public float KBForce; // fuerza de knockback
    public float KBCounter; // contador de knockback
    public float KBTotalTime; // duración total del knockback
    public bool knockFromRight; // si recibe el knockback de la derecha o no
    private bool isGrounded; // si está en el suelo o no

    [SerializeField] private float horizontalSpeed; // creamos variable serializada de la velocidad de movimiento
    private float dirX; // creamos variable de dirección en el eje x
    string facingDirection; // dirección a la que se está mirando
    Vector3 baseScale; // escala base

    private enum MovementState { idle, running, jumping, falling }; // listado de los diferentes estados

    [SerializeField] private AudioSource jumpSFX; // el sonido de salto

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // asignamos el rigidbody a la variable
        coll = feet.GetComponent<BoxCollider2D>(); // asignamos el colisionador a la variable
        anim = GetComponent<Animator>(); // asignamos el animador a la variable
        facingDirection = RIGHT;
        baseScale = transform.localScale;
        jumpForce = 20f;
        horizontalSpeed = 7f;
        KBForce = 5f;
        KBTotalTime = 0.2f;  
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            dirX = Input.GetAxisRaw("Horizontal"); // asignamos valor del eje X en función de la tecla presionada

            if (Input.GetButtonDown("Jump") && IsGrounded()) // si presionamos la tecla de salto y estamos en el suelo
            {
                jumpSFX.Play();
                rb.velocity = Vector2.up * jumpForce; // si se salta, se aplica una fuerza vertical y se mantiene la velocidad horizontal
            }
            UpdateAnimationState(); // actualizamos el estado de animación
        }
    }

    private void FixedUpdate()
    {
        if(KBCounter <= 0) // mientras no haya knockback aplicado
        {
            if(dirX > 0.1f || dirX < -0.1f)
            {
                rb.velocity = new Vector2(dirX * horizontalSpeed, rb.velocity.y); // la velocidad horizontal variará en función de la dirección, la velocidad vertical será la acutal          
            }
        }
        else
        {
            if(knockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce); // se aplica la fuerza de knockback en negativo
            }
            if(knockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce); // se aplica la fuerza de knockback en positivo
            }

            KBCounter -= Time.deltaTime; // se descuenta el contador 
        }
    }

    private void UpdateAnimationState() // cambio de estados de animación
    {
        MovementState state;

        if (dirX > 0.1f) // si la dirección es positiva, nos movemos a la derecha
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

    private bool IsGrounded() // mira si está tocando suelo
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround); // se hace un boxcast del colisionador del jugador sobre todo lo que esté marcado como "jumpableGround"
    }
}
