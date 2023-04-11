using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource collectSFX;
    [SerializeField] private int value;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collectSFX.Play();
            GameManager.instance.CollectibleCollected(value);
            anim.SetTrigger("collected");
        }
    }

    private void Disappear()
    {
        Destroy(gameObject);
    }

}
