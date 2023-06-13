using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionPopUp : MonoBehaviour
{
    public GameObject tutorialContainer; // objeto del contenedor de tutorial/instrucciones
    public GameObject[] HUDElements;
    public GameObject tipPopups; // objeto de consejos
    public Button skipBtn; // bot�n para saltar el tutorial y jugar
    public Button nextBtn; // bot�n para pasar al siguiente tutorial

    private int currentIndex = 0; // mantener control del �ndice actual de popups

    void Start()
    {
        tutorialContainer.SetActive(true); // por defecto se activa el tutorial
        Time.timeScale = 0f; // se para el tiempo
        HideAllPopUps();
    }

    public void FirstPopUp() // Ense�a el primer tutorial
    {
        ShowTutorialPopUp();
        nextBtn.gameObject.SetActive(false);
    }

    public void NextPopUp() // Ense�a el siguiente tutorial
    {
        HideTutorialPopUp(); // Esconde el actual

        currentIndex++; // pasa al siguiente �ndice
        if (currentIndex < HUDElements.Length)
        {
            ShowTutorialPopUp(); // Ense�a el actual
        }
        else
        {
            EndTutorial(); // Cuando llega al final acaba el tutorial
        }
    }

    private void ShowTutorialPopUp() // Mostrar tutorial
    {
        // Activa el elemento del HUD actual
        HUDElements[currentIndex].SetActive(true);

        // Activa el bot�n de "Siguiente"
        nextBtn.interactable = true;
    }

    private void HideTutorialPopUp() // Esconder tutorial
    {
        // Esconde el elemento del HUD actual
        HUDElements[currentIndex].SetActive(false);

        // Desactiva el bot�n de "Siguiente"
        nextBtn.interactable = false;
    }

    private void HideAllPopUps()
    {
        // Esconde todo los elementos
        foreach (var element in HUDElements)
        {
            element.SetActive(false);
        }
    }
    
    private void EndTutorial() // Acabar Tutorial
    {
        HideAllPopUps(); // esconde todos
        nextBtn.interactable = false;
        ResumeGame(); // Resume juego
    }

    public void ResumeGame()
    {
        tutorialContainer.SetActive(false); // se desactiva el panel de pausa
        Time.timeScale = 1f; // se reanuda el tiempo
        PauseMenu.isPaused = false; // ya no est� pausado
        tipPopups.SetActive(true); // se activan los consejos
    }
}
