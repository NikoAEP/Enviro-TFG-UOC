using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private GameObject cam;
    
    private float startPosition;
    private float length;
    [SerializeField] private float parallaxFactor;


    public void Start()
    {
        cam = GameObject.Find("CM Cam");
        startPosition = transform.position.x;
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public void Update()
    {
        float temp = (cam.transform.position.x * (1-parallaxFactor));
        float distance = (cam.transform.position.x * parallaxFactor);
        
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if(temp > startPosition + length) 
        {
            startPosition += length;
        }
        else if(temp < startPosition - length) 
        {
            startPosition -= length;
        }
    }

}
