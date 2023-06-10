using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollutionUI : MonoBehaviour
{
    [SerializeField] private Image[] pollutionLevel; // imágenes de niveles de contaminación
    private int currentDifficulty; // dificultad actual
    void Start()
    {
        currentDifficulty = GameManager.instance.difficulty; // la dificultad actual es la dificultad que dicta el GameManager
    }

    void Update()
    {
        PollutionBarFiller(); // se actualiza la barra de contaminación
    }
    
    void PollutionBarFiller()
    {
        for(int i = 0; i < pollutionLevel.Length; i++) // de 0 al número totales de imágenes
        {
            pollutionLevel[i].enabled = DisplayPollutionLevel(currentDifficulty, i); // se activa la imagen según la dificultad actual
        }
    }

    bool DisplayPollutionLevel(int difficulty, int pollution) // se decide si enseñar la imagen
    {
        return (pollution <= difficulty); // si la contaminación es menor que la dificultad, se muestra
    }
}
