using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false); // por defecto se desactiva el menú de pausa
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // si se apreta Esc,
        {
            if(isPaused) // si está pausado
            {   
                ResumeGame(); // continúa el juego
            }
            else
            {
                PauseGame(); // se pausa el juego
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); // se activa el panel de pausa
        Time.timeScale = 0f; // se para el tiempo
        isPaused = true; // está pausado
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // se desactiva el panel de pausa
        Time.timeScale = 1f; // se reanuda el tiempo
        isPaused = false; // ya no está pausado
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // se reanuda el tiempo
        SceneManager.LoadSceneAsync("Main Menu"); // se carga la escena del menú
        isPaused = false; // ya no está pausado
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

