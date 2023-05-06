using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionPopUp : MonoBehaviour
{
    public GameObject tutorialContainer;
    public static bool isPaused;

    void Start()
    {
        tutorialContainer.SetActive(true); // por defecto se activa el tutorial
        Time.timeScale = 0f; // se para el tiempo
        isPaused = true; // está pausado
    }

    public void ResumeGame()
    {
        tutorialContainer.SetActive(false); // se desactiva el panel de pausa
        Time.timeScale = 1f; // se reanuda el tiempo
    }
}
