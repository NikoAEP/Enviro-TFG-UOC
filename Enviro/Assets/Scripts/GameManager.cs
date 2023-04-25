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
    public int difficulty;
    public int maxDifficulty = 2;

    public UnitHealth _playerHealth = new UnitHealth(100, 100);  
    
    public int currentScore = 0;
    public int overallScore = 0;    

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {   
            instance = this;
            DontDestroyOnLoad(this);
        }        
    }

    private void Start()
    {
        difficulty = 0;
        ResetGame();
    }
        
    public void EnemyDestroyed(int points)
    {
        currentScore += points;
        ScoreManager.instance.UpdateScore(currentScore);
    }
    public void CollectibleCollected(int points)
    {
        currentScore += points;
        ScoreManager.instance.UpdateScore(currentScore);
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
        gameOver = true;
        StartCoroutine(LoadLevel(3));
        ResetGame();
    }

    public void ResetGame()
    {
        gameOver = false;
        currentScore = 0;
        overallScore = 0; 
    }    

    public IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelIndex);
    }
}
