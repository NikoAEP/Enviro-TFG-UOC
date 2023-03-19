using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // array de puntos
    private int currentWaypointIndex = 0; // indíce de puntos en el array de puntos

    [SerializeField] private float speed = 2f; // velocidad a la que se mueve el objeto
    private SpriteRenderer sprite; // creamos variable del sprite de animación

    private void Start()
        {
            sprite = GetComponent<SpriteRenderer>(); // asignamos el sprite al variable
        }
        
    private void Update()
    {
        // si la distancia entre un punto y lo que se mueve es pequeña, estamos en ese punto
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++; // cambiamos al siguiente punto
            sprite.flipX = true;
            if (currentWaypointIndex >= waypoints.Length) // si llegamos al último punto
            {
                currentWaypointIndex = 0; // volvemos al primero
                sprite.flipX = false;
            }
        }
        // movemos el objecto hacia el punto actual a la velocidad definida por segundo
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
