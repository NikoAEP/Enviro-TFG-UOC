using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Collectible")
            {
                print("Item has been collected");
                var recycloAnim = collision.gameObject.GetComponent<Animator>();
                recycloAnim.Play("Recyclo_Disappear");
                Destroy(collision.gameObject);
            }
    }
}
