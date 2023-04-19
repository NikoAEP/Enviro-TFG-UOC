using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private EnemyType type;
    [SerializeField] private AudioSource destroySFX;
    [SerializeField] private AudioSource dieSFX;

    private int maxHealth;
    private int currentHealth;
    
    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        maxHealth = type.health;
        currentHealth = maxHealth;
    }

    public void receiveDamage(int damage)
    {
        currentHealth -= damage;
        print("enemy health: " + currentHealth);
        if (currentHealth <= 0)
            {
                GameManager.instance.EnemyDestroyed(type.value);
                destroySFX.Play();
                anim.Play("Suraba_Death");
                Invoke("Die", 0.7f);            
            }
    }

    private void Die()
    {        
        Destroy(gameObject);   
    }

}
