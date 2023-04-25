using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleController : MonoBehaviour
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
        if (collision.tag == "Player")
        {
            collectSFX.Play();
            GameManager.instance.CollectibleCollected(type.value);
            anim.Play("Recyclos_Disappear");
            Invoke("Disappear", 0.6f);
        }
    }

    private void Disappear()
    {
        Destroy(gameObject);
    }

}
