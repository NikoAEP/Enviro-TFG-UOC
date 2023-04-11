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
    /*[SerializeField] private int attackDamage;
    [SerializeField] private int value;*/
    
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
            GameManager.instance.TakeDamage(type.attackDamage);        
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && currentHealth > 0)
        {
            currentHealth -= 5;
            //anim.SetTrigger("hit");
        }
        if (currentHealth == 0)
        {
            GameManager.instance.EnemyDestroyed(type.value);
            anim.SetTrigger("death");
            destroySFX.Play();
        }
    }

    private void Die()
    {        
        Destroy(gameObject);   
    }

}
