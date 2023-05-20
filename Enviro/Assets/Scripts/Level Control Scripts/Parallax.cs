using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private GameObject cam; // objeto de c�mara
    
    private float startPosition; // posici�n inicial
    private float length; // largo de la imagen 
    [SerializeField] private float parallaxFactor; // factor de parallax


    public void Start()
    {
        cam = GameObject.Find("CM Cam"); // se coge la c�mara
        startPosition = transform.position.x; // la posici�n inicial es la posici�n x
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x; // se coge el largo de la imagen
    }

    public void Update()
    {
        float temp = (cam.transform.position.x * (1-parallaxFactor)); // valor temporal para luego poner la imagen a la izquierda o derecha
        float distance = (cam.transform.position.x * parallaxFactor); // la distancia es la posici�n de la c�mara multiplicada por el valor de parallax

        // la posici�n ser� la posici�n inicial m�s la distancia, y las posiciones Y y z
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z); 

        if(temp > startPosition + length) // si el valor temporal es mayor a la posici�n inicial m�s el largo de la imagen
        {
            startPosition += length; // se le suma el largo de la imagen a la posici�n inicial, para poner la imagen a la derecha
        }
        else if(temp < startPosition - length) // si es menor
        {
            startPosition -= length; // se le resta, para poner la imagen a la izquierda
        }
    }

}
