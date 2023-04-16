using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    private AudioSource winSFX; // audio que suena al llegar a la meta
       
    private void Start()
    {
        winSFX = GetComponent<AudioSource>(); // se busca el componente de audio
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player") // cuando el objeto con nombre "Player" entra en el colisionador
        {
            winSFX.Play(); // suena el audio
            GameManager.instance.LoadNextLevel(); // se le dice al GM que cargue el siguiente nivel
       }        
    }
}
