using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollutionUI : MonoBehaviour
{
    [SerializeField] private Image[] pollutionLevel; // im�genes de niveles de contaminaci�n
    private int currentDifficulty; // dificultad actual
    void Start()
    {
        currentDifficulty = GameManager.instance.difficulty; // la dificultad actual es la dificultad que dicta el GameManager
    }

    void Update()
    {
        PollutionBarFiller(); // se actualiza la barra de contaminaci�n
    }
    
    void PollutionBarFiller()
    {
        for(int i = 0; i < pollutionLevel.Length; i++) // de 0 al n�mero totales de im�genes
        {
            pollutionLevel[i].enabled = DisplayPollutionLevel(currentDifficulty, i); // se activa la imagen seg�n la dificultad actual
        }
    }

    bool DisplayPollutionLevel(int difficulty, int pollution) // se decide si ense�ar la imagen
    {
        return (pollution <= difficulty); // si la contaminaci�n es menor que la dificultad, se muestra
    }
}
