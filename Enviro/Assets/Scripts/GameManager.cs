using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public bool gameOver = false;
    public bool gamePaused = true;
    public int difficulty;
    public int maxDifficulty = 2;

    public UnitHealth _playerHealth = new UnitHealth(100, 100); // se crea una nueva vida de jugador

    public int currentScore = 0;
    public int overallScore = 0;

    public int cleanLevels = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {   
            instance = this;
            DontDestroyOnLoad(this); // se asegura de no destruir esta instancia
        }        
    }

    private void Start()
    {
        difficulty = 0; // dificultad por defecto
        ResetGame(); // resetea el resto de par�metors
    }
        
    public void EnemyDestroyed(int points)
    {
        currentScore += points; // suma los puntos pasados
        ScoreManager.instance.UpdateScore(currentScore); // actualiza la puntuaci�n en el Score Manager
    }
    public void CollectibleCollected(int points)
    {
        currentScore += points; // suma los puntos pasados
        ScoreManager.instance.UpdateScore(currentScore); // actualiza la puntuaci�n en el Score Manager
    }

    // M�todo para calcular la dificultad
    public void CalculateDifficulty() 
    {
        int newDifficulty = difficulty; // valor temporal de la dificultad
        if(currentScore < 20) // si la puntuaci�n actual es inferior a 20
        {
            newDifficulty++; // aumenta la dificultad
        }
        if (currentScore >= 20 && currentScore < 30) // si la puntuaci�n actual est� entre 20 y 29
        {
            cleanLevels++; // se a�ade un nivel limpio
            newDifficulty = difficulty; // mant�n la dificultad actual
        }
        if(currentScore >= 30) // si la puntuaci�n actual es 30 o m�s
        {
            cleanLevels++; // se a�ade un nivel limpio
            newDifficulty--; // se disminuye la dificultad
        }

        if(newDifficulty >= maxDifficulty) // si la dificultad nueva es superior a la m�xima (2)
        {
            newDifficulty = maxDifficulty; // es la m�xima
        }
        if(newDifficulty <= 0) // si es inferior o igual a 0
        {
            newDifficulty = 0; // es 0
        }
        difficulty = newDifficulty; // la dificultad es la nueva dificultad
    }

    // M�todo para cargar el siguiente nivel
    public void LoadNextLevel()
    {
        overallScore += currentScore; // se suma la puntuaci�n actual a la total
        print("Overall Score: " + overallScore);
        CalculateDifficulty(); // se calcula la nueva dificultad
   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // se coge el �ndice actual
        int nextSceneIndex = 1; // el siguiente indice ser� 1 (por defecto)
        if(currentSceneIndex > 0 && currentSceneIndex <= 3) // si el �ndice actual es entre 0 y 3 (el nivel 1 en sus diferentes niveles de contaminaci�n)
        {
            nextSceneIndex = 2; // el siguiente �ndice es 2
        }
        if(currentSceneIndex > 3 && currentSceneIndex <= 6) // si el �ndice actual es entre 4 y 6 (el nivel 2 en sus diferentes niveles de contaminaci�n)
        {
            nextSceneIndex = 3; // el siguiente �ndice es 3
        }
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings) // mientras estemos dentro de todos los niveles disponibles
        {
            StartCoroutine(LoadLevel(nextSceneIndex, difficulty)); // carga el siguiente nivel con el nivel de dificultad indicado
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver() // m�todo que muestra la pantalla de fin del juego
    {
        gameOver = true;
        gamePaused = true;
        SceneManager.LoadScene("Game_Over");
    }

    public void ResetGame() // se reseta el juego
    {
        gameOver = false;
        currentScore = 0;
        overallScore = 0; 
    }    

    public IEnumerator LoadLevel(int levelIndex, int diffLevel)
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Level_"+ levelIndex + "_" + diffLevel);
    }
}
