using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionPopUp : MonoBehaviour
{
    public GameObject tutorialContainer; // objeto del contenedor de tutorial/instrucciones
    public GameObject mainUI; // objeto del UI/HUD principal
    public static bool isPaused; // variable de pausa

    void Start()
    {
        tutorialContainer.SetActive(true); // por defecto se activa el tutorial
        Time.timeScale = 0f; // se para el tiempo
        isPaused = true; // está pausado
        mainUI.SetActive(false); // se desactiva el HUD 
    }

    public void ResumeGame()
    {
        tutorialContainer.SetActive(false); // se desactiva el panel de pausa
        Time.timeScale = 1f; // se reanuda el tiempo
        PauseMenu.isPaused = false; // ya no está pausado
        mainUI.SetActive(true); // se reaactiva el HUD 
    }
}
