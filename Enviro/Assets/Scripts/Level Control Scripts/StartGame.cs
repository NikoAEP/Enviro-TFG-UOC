using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public Animator transition; // se guarda el controlador de animaciones de la transición
    public GameObject transitionContainer; // se guarda el contenedor de la transición

    public void NewGame()
    {
        GameManager.instance.ResetGame(); // primero se resetea el juego 
        transitionContainer.SetActive(true); // se activa el panel de animación de transición
        StartCoroutine(LoadLevel(GameManager.instance.difficulty)); // se carga el primer nivel 
    }

    IEnumerator LoadLevel(int diffLevel) // Carga el nivel con delay suficiente para realizar la transición 
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level_1_" + diffLevel);
    }
}
