using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource destroySFX;
    [SerializeField] private AudioSource damageSFX;
    [SerializeField] private AudioSource dieSFX;

    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        GameManager.instance.TakeDamage(damage);
        anim.Play("Player_Hit");
        damageSFX.Play();  

        if(GameManager.instance.currentHealth <= 0)
        {
            dieSFX.Play();
            Die();
        }
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.Play("Player_Death");
        GameManager.instance.GameOver();
    }

}
