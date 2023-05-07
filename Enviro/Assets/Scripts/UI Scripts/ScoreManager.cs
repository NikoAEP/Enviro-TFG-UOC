using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TMP_Text scoreText;
    private int score;
    
    private void Awake()
    {
        instance = this;        
    }
    
    void Start()
    {
        score = GameManager.instance.currentScore;
        scoreText.text = score.ToString();
    }

    public void UpdateScore(int value)
    {
        scoreText.text = value.ToString();
        print("Current score: " + value);
    }
}
