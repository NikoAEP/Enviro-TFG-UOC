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
    private int score; // puntuaci�n
        
    void Start()
    {
        score = GameManager.instance.currentScore; // la puntuaci�n es el valor de la puntuaci�n actual
        ScoreManager.instance.UpdateScore(score); // actualiza la puntuaci�n en el Score Manager
    }

    void Update()
    {
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
