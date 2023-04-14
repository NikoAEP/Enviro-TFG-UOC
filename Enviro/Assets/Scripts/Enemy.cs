using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private EnemyType type;
    [SerializeField] private AudioSource destroySFX;
    [SerializeField] private AudioSource dieSFX;
    private int maxHealth;
    private int currentHealth;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        maxHealth = type.health;
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && GameManager.instance.currentHealth > 0)
        {
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            if (direction.y < 0.5f)
            {
                GameManager.instance.TakeDamage(type.attackDamage);   
            }    
        }   
    }

    public void receiveDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            {
                GameManager.instance.EnemyDestroyed(type.value);
                destroySFX.Play();
                anim.Play("Suraba_Death");            
            }
    }

    private void Die()
    {        
        Destroy(gameObject);   
    }

}
