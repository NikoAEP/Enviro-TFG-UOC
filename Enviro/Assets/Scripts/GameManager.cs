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
    }

    public void LoadNextLevel()
    {
        overallScore += currentScore;
        CalculateDifficulty();        
   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = 1;
        if(currentSceneIndex > 0 && currentSceneIndex <= 3)
        {
            nextSceneIndex = 2;
        }
        if(currentSceneIndex > 3 && currentSceneIndex <= 6)
        {
            nextSceneIndex = 3;
        }
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(LoadLevel(nextSceneIndex, difficulty));
        }
        else
        {
            Debug.Log("You've reached the end of the game!");
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gamePaused = true;
        SceneManager.LoadScene("Game_Over");
        ResetGame();
    }

    public void ResetGame()
    {
        gameOver = false;
        currentScore = 0;
        overallScore = 0; 
    }    

    public IEnumerator LoadLevel(int levelIndex, int diffLevel)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level_"+ levelIndex + "_" + diffLevel);
    }
}
