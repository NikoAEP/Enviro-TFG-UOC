using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource collectSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible01"))
        {
            collectSFX.Play();
            Destroy(collision.gameObject);
            GameManager.instance.CollectibleCollected(5);
        }
    }
}
