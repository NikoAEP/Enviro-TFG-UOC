using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicControl : MonoBehaviour
{
    public static BGMusicControl instance; // se crea una instancia de la música de fondo
    private void Awake()
    {
        if(instance != null) // si no es nula, es decir que ya hay otra instancia
        {
            Destroy(gameObject); // se elimina
        }
        else
        {
            instance = this; // si no, esta es la instancia
            DontDestroyOnLoad(this.gameObject); // se indica de no destruir
        }        
    }
}
