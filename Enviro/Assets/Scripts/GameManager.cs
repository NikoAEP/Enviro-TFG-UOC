using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int difficulty = 2;
    public int currentLevel = 1;
    public int maxLevel = 3;

    public int maxHealth = 100; 
    public int currentHealth = 100;
    
    public int currentScore = 0;
    public int overallScore = 0;    

    public Text healthText;
    public Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }        
    }

    private void Start()
    {
        difficulty = 2; // dificultad por defecto
        currentHealth = maxHealth;
        currentScore = 0;
        overallScore = 0; 
        UpdateHealthUI();
        UpdateScoreUI();
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();
    }
    
    public void EnemyDestroyed(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }
    public void CollectibleCollected(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }

    public void LoadNextLevel()
    {
        overallScore += currentScore;
        difficulty = (overallScore / 2); // Determine difficulty based on total score

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

    public void GameOver()
    {
        SceneManager.LoadScene("End_Screen");
        difficulty = 1; // dificultad por defecto
        currentHealth = maxHealth;
        currentScore = 0;
        overallScore = 0; 
        UpdateHealthUI();
        UpdateScoreUI();
    }
}
