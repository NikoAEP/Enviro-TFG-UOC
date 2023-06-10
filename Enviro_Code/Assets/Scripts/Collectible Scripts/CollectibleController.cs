using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleController : MonoBehaviour
{
    private Animator anim; // animador del Recyclo
    [SerializeField] private CollectibleType type; // Tipo de Recyclo
    [SerializeField] private AudioSource collectSFX; // objeto de sonido para cuando se colecciona


    private void Start()
    {
        anim = GetComponent<Animator>(); // se coge el componente de animador
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // si el jugador entra en contacto
        {
            collectSFX.Play(); // suena el sonido de colección
            GameManager.instance.CollectibleCollected(type.value); // se pasa el valor del tipo de Recyclo al controlador de puntuación del GameManager
            anim.Play("Recyclos_Disappear"); // se inicia la animación
            Invoke("Disappear", 0.5f); // se invoka la desaparición 
        }
    }

    private void Disappear()
    {
        Destroy(gameObject); // se elimina el objeto
    }

}
