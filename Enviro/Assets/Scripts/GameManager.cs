using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int difficulty;
    public int health;
    public int collected;
    public int destroyed;
    public int score;    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }        
    }

    private void Start()
    {
        difficulty = 1; // dificultad por defecto
        health = 100;
        collected = 0;
        destroyed = 0;
        score = 0;
    }

    public void LoadNextLevel(int collectibleScore, int enemyScore)
    {
        int levelScore = collectibleScore + enemyScore;

        difficulty = levelScore / 2; // Determine difficulty based on total score

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("You've reached the end of the game!");
        }
    }
}
