using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    [SerializeField] private HealthManager _healthManager;
    [SerializeField] private ScoreManager _scoreManager;   
    [SerializeField] private AudioSource destroySFX;
    [SerializeField] private AudioSource damageSFX;
    [SerializeField] private AudioSource dieSFX;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public void PlayerTakeDamage (int damage)
    {
        anim.Play("Player_Hit");
        damageSFX.Play();  
        GameManager.instance._playerHealth.TakeDamage(damage);
        _healthManager.SetHealth(GameManager.instance._playerHealth.Health);
        print("Player Health: " + GameManager.instance._playerHealth.Health);

        if(GameManager.instance._playerHealth.Health <= 0)
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
