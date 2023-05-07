using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TipsController : MonoBehaviour
{
    [SerializeField] private TMP_Text textBox;
    [SerializeField] private float popupDuration = 15f;
    [SerializeField] private float popupInterval = 1f;
    [SerializeField] private PopupTextSO popupTextData;

    private float popupTimer = 0f;

    private void Start()
    {
        textBox.text = popupTextData.popupTexts[Random.Range(0, popupTextData.popupTexts.Length)];
    }

    private void Update()
    {
        popupTimer += Time.deltaTime;

        if (popupTimer >= popupDuration)
        {
            popupTimer = 0f;
            string randomText = popupTextData.popupTexts[Random.Range(0, popupTextData.popupTexts.Length)];
            StartCoroutine(ShowPopupText(randomText));
        }
    }

    private IEnumerator ShowPopupText(string text)
    {
        textBox.text = text;
        yield return new WaitForSeconds(popupInterval);
    }
}
