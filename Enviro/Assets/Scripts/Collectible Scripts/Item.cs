using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private CollectibleType type;
    [SerializeField] private AudioSource collectSFX;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collectSFX.Play();
            GameManager.instance.CollectibleCollected(type.value);
            anim.SetTrigger("collected");
        }
    }

    private void Disappear()
    {
        Destroy(gameObject);
    }

}
