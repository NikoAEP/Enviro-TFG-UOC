using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // instancia del controlador de puntuación
    
    public TMP_Text scoreText; // el texto donde se guarda la puntuación
    private int score; // el valor de puntuación
    
    private void Awake()
    {
        instance = this;        
    }
    
    void Start()
    {
        score = GameManager.instance.currentScore; // el valor de puntuación es el que tenga el GameManager
        scoreText.text = score.ToString(); // el texto es el valor pasado a String
    }

    public void UpdateScore(int value) // Actualiza la puntuación
    {
        scoreText.text = value.ToString(); // se convierte a string el valor que se pasa
        print("Current score: " + value);
    }
}
