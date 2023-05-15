using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    public void ToMainMenu()
    {
        Time.timeScale = 1f; // se reanuda el tiempo
        SceneManager.LoadSceneAsync("Menu"); // se carga la escena del menú
    }
}
