using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private CollectibleType type;
    [SerializeField] private AudioSource collectSFX;

    private ScoreManager scoreManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        scoreManager = GameObject.Find("UICanvas").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collectSFX.Play();
            scoreManager.score += type.value;
            //GameManager.instance.CollectibleCollected(type.value);
            anim.SetTrigger("collected");
        }
    }

    private void Disappear()
    {
        Destroy(gameObject);
    }

}
