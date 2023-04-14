using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.CompareTag("Enemy_01"))
            {
                var enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.receiveDamage(5);
            }
        }
    }
}
