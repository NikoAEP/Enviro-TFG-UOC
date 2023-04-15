using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weak Point")
            {
                print("Enemy weak point collided");
                var enemy = collision.gameObject.GetComponent<EnemyHealth>();
                enemy.receiveDamage(5);
                print("enemy health: " + enemy.currentHealth);
            }
    }
}
