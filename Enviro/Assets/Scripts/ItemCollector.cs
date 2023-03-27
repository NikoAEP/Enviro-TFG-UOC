using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text score;

    [SerializeField] private AudioSource collectSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible01"))
        {
            collectSFX.Play();
            Destroy(collision.gameObject);
            GameManager.instance.collected++;
            score.text = GameManager.instance.collected.ToString();
        }
    }
}
