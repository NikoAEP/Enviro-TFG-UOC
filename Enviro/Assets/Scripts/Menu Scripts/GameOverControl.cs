using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverControl : MonoBehaviour
{

    public GameObject wonText;
    public GameObject lostText;
    public GameObject diedText;
    public TMP_Text scoreText;
    private int score;
        
    void Start()
    {
        score = GameManager.instance.overallScore;
        scoreText.text = score.ToString();      
    }

    void Update()
    {
        scoreText.text = score.ToString();

        if (GameManager.instance._playerHealth.Health <= 0)
        {
            wonText.SetActive(false); // por defecto se desactiva el texto de haber ganado
            lostText.SetActive(false); // por defecto se desactiva el texto de haber perdido
            diedText.SetActive(true); // por defecto se desactiva el texto de haber muerto
        }
        else if (GameManager.instance.cleanLevels >= 2)
        {
            wonText.SetActive(true); // por defecto se desactiva el texto de haber ganado
            lostText.SetActive(false); // por defecto se desactiva el texto de haber perdido
            diedText.SetActive(false); // por defecto se desactiva el texto de haber muerto
        }
        else
        {
            wonText.SetActive(false); // por defecto se desactiva el texto de haber ganado
            lostText.SetActive(true); // por defecto se desactiva el texto de haber perdido
            diedText.SetActive(false); // por defecto se desactiva el texto de haber muerto
        }
    }

}
