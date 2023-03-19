using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private Text healthTxt;
    [SerializeField] private int health = 100;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy_01"))
        {
            health -= 5;
            healthTxt.text = "Health: " + health;
            if(health <= 0)
            {
                Die();
            }            
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
