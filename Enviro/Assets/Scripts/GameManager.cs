using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int difficulty;
    public int maxDifficulty = 2;

    public int maxHealth = 100; 
    public int currentHealth = 100;
    
    public int currentScore = 0;
    public int overallScore = 0;    

    public TMP_Text healthText;
    public TMP_Text scoreText;

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
        difficulty = 0;
        ResetGame();
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

    public void CalculateDifficulty()
    {
        print("Previous Difficulty: " + difficulty);
        int newDifficulty = difficulty;
        if(currentScore < 20)
        {
            newDifficulty++;
        }
        else if (currentScore >= 20 && currentScore < 30)
        {
            newDifficulty = difficulty;
        }
        else
        {
            newDifficulty--;
        }

        if(newDifficulty >= maxDifficulty)
        {
            newDifficulty = maxDifficulty;
        }
        if(newDifficulty <= 0)
        {
            newDifficulty = 0;
        }
        difficulty = newDifficulty;
        print("New Difficulty: " + difficulty);
    }

    public void LoadNextLevel()
    {
        overallScore += currentScore;
        CalculateDifficulty();        
   
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(LoadLevel((nextSceneIndex)));
        }
        else
        {
            Debug.Log("You've reached the end of the game!");
        }
    }

    public void GameOver()
    {
        StartCoroutine(LoadLevel(3));
        ResetGame();
    }

    public void ResetGame()
    {
        currentHealth = maxHealth;
        currentScore = 0;
        overallScore = 0; 
        UpdateHealthUI();
        UpdateScoreUI();
    }    

    public IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelIndex);
    }
}
