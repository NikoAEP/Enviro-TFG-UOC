using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicControl : MonoBehaviour
{
    public static BGMusicControl instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }        
    }
}
