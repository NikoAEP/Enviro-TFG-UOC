using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    private AudioSource winSFX;

    private bool levelCompleted = false;
    
    private void Start()
    {
        winSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            winSFX.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
            GameManager.instance.currentLevel++;
            GameManager.instance.LoadNextLevel();
       }
        
    }

}
