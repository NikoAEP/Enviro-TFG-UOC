using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyType type;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && GameManager.instance.currentHealth > 0)
        {
           print("Enemy hit player");
           collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(type.attackDamage);    
        }   
    }
}
