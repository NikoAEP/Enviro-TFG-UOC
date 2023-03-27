using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private Text healthTxt;

    [SerializeField] private Text trashDestroyed;

    [SerializeField] private AudioSource destroySFX;
    [SerializeField] private AudioSource damageSFX;
    [SerializeField] private AudioSource dieSFX;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy_01") && GameManager.instance.health > 0)
        {
            GameManager.instance.health -= 5;
            healthTxt.text = GameManager.instance.health.ToString();
            damageSFX.Play();
                  
        }
        if(GameManager.instance.health <= 0)
            {
                dieSFX.Play();
                Die();
            }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_01"))
        {
            destroySFX.Play();
            Destroy(collision.gameObject);
            GameManager.instance.destroyed++;
            trashDestroyed.text = GameManager.instance.destroyed.ToString();
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
