using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; // creamos variable serializada para aplicar el transform del jugador

    private void Update()
    {
        // cambiamos la posición x e y de la cámara en función de la posición del jugador
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
