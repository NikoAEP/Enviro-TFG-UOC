using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

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
        if(collision.gameObject.CompareTag("Enemy_01") && GameManager.instance.currentHealth > 0)
        {
            GameManager.instance.TakeDamage(5);
            damageSFX.Play();
                  
        }
        if(GameManager.instance.currentHealth <= 0)
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
            GameManager.instance.EnemyDestroyed(5);
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
