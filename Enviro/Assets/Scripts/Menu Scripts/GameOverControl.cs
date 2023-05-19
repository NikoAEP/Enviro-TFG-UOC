using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverControl : MonoBehaviour
{

    public GameObject wonText; // texto en caso de ganar
    public GameObject lostText; // texto en caso de perder
    public GameObject diedText; // texto en caso de muerte
    public TMP_Text scoreText; // texto de puntuación
    private int score; // puntuación
        
    void Start()
    {
        score = GameManager.instance.overallScore; // la puntuación es el valor de la puntuación total
        scoreText.text = score.ToString(); // el texto es el valor pasado a texto
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
