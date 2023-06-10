using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private GameObject cam; // objeto de cámara
    
    private float startPosition; // posición inicial
    private float length; // largo de la imagen 
    [SerializeField] private float parallaxFactor; // factor de parallax


    public void Start()
    {
        cam = GameObject.Find("CM Cam"); // se coge la cámara
        startPosition = transform.position.x; // la posición inicial es la posición x
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x; // se coge el largo de la imagen
    }

    public void Update()
    {
        float temp = (cam.transform.position.x * (1-parallaxFactor)); // valor temporal para luego poner la imagen a la izquierda o derecha
        float distance = (cam.transform.position.x * parallaxFactor); // la distancia es la posición de la cámara multiplicada por el valor de parallax

        // la posición será la posición inicial más la distancia, y las posiciones Y y z
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z); 

        if(temp > startPosition + length) // si el valor temporal es mayor a la posición inicial más el largo de la imagen
        {
            startPosition += length; // se le suma el largo de la imagen a la posición inicial, para poner la imagen a la derecha
        }
        else if(temp < startPosition - length) // si es menor
        {
            startPosition -= length; // se le resta, para poner la imagen a la izquierda
        }
    }

}
