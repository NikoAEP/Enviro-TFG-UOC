using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int collected = 0;
    [SerializeField] private Text score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible01"))
        {
            Destroy(collision.gameObject);
            collected++;
            score.text = "Score: " + collected;
        }
    }
}
