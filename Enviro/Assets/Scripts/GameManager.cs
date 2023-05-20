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
        ResetGame(); // resetea el resto de parámetors
    }
        
    public void EnemyDestroyed(int points)
    {
        currentScore += points; // suma los puntos pasados
        ScoreManager.instance.UpdateScore(currentScore); // actualiza la puntuación en el Score Manager
    }
    public void CollectibleCollected(int points)
    {
        currentScore += points; // suma los puntos pasados
        ScoreManager.instance.UpdateScore(currentScore); // actualiza la puntuación en el Score Manager
    }

    // Método para calcular la dificultad
    public void CalculateDifficulty() 
    {
        int newDifficulty = difficulty; // valor temporal de la dificultad
        if(currentScore < 20) // si la puntuación actual es inferior a 20
        {
            newDifficulty++; // aumenta la dificultad
        }
        if (currentScore >= 20 && currentScore < 30) // si la puntuación actual está entre 20 y 29
        {
            cleanLevels++; // se añade un nivel limpio
            newDifficulty = difficulty; // mantén la dificultad actual
        }
        if(currentScore >= 30) // si la puntuación actual es 30 o más
        {
            cleanLevels++; // se añade un nivel limpio
            newDifficulty--; // se disminuye la dificultad
        }

        if(newDifficulty >= maxDifficulty) // si la dificultad nueva es superior a la máxima (2)
        {
            newDifficulty = maxDifficulty; // es la máxima
        }
        if(newDifficulty <= 0) // si es inferior o igual a 0
        {
            newDifficulty = 0; // es 0
        }
        difficulty = newDifficulty; // la dificultad es la nueva dificultad
    }

    // Método para cargar el siguiente nivel
    public void LoadNextLevel()
    {
        overallScore += currentScore; // se suma la puntuación actual a la total
        print("Overall Score: " + overallScore);
        CalculateDifficulty(); // se calcula la nueva dificultad
   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // se coge el índice actual
        int nextSceneIndex = 1; // el siguiente indice será 1 (por defecto)
        if(currentSceneIndex > 0 && currentSceneIndex <= 3) // si el índice actual es entre 0 y 3 (el nivel 1 en sus diferentes niveles de contaminación)
        {
            nextSceneIndex = 2; // el siguiente índice es 2
        }
        if(currentSceneIndex > 3 && currentSceneIndex <= 6) // si el índice actual es entre 4 y 6 (el nivel 2 en sus diferentes niveles de contaminación)
        {
            nextSceneIndex = 3; // el siguiente índice es 3
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

    public void GameOver() // método que muestra la pantalla de fin del juego
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
