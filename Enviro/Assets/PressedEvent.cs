using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PressedEvent : MonoBehaviour
{
    public TMP_Text text;
    bool pressed;

    void Start()
    {
        pressed = false;        
    }

    void Update()
    {
        if (!pressed)
        {
            text.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 6.8f);
            text.color = new Color32(255, 255, 255, 255);
        }
    }

    public void onPress()
    {
        text.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f);
        text.color = new Color32(161, 201, 255, 255);
        pressed = false;
    }

}
