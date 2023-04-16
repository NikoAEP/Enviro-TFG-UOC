using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";

    Rigidbody2D rb; // creamos variable del Rigidbody
    
    [SerializeField] Transform castPos;
    [SerializeField] float baseCastDist;  
    [SerializeField] private float horizontalSpeed = 5f; // creamos variable serializada de la velocidad de movimiento
    
    string facingDirection;
    Vector3 baseScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // asignamos el rigidbody a la variable
        facingDirection = RIGHT;
        baseScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        float vX = horizontalSpeed;
        if(facingDirection == LEFT)
        {
            vX = -horizontalSpeed;  
        } 

        rb.velocity = new Vector2(vX, rb.velocity.y);

        if(isHittingWall() || isNearEdge())
        {
            if(facingDirection == LEFT)
            {
                changeFacingDirection(RIGHT);
            }
            else
            {
                changeFacingDirection(LEFT);
            }
        }
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

    private bool isHittingWall()
    {
        bool val = false;

        float castDist = baseCastDist;

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

    private bool isNearEdge()
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
