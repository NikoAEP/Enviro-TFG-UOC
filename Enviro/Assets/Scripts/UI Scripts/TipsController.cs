using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;

public class TipsController : MonoBehaviour
{
    [SerializeField] private TMP_Text textBox;
    [SerializeField] private float popupDuration = 15f;
    [SerializeField] private float popupInterval = 1f;
    [SerializeField] private PopupTextSO popupTextDataEN;
    [SerializeField] private PopupTextSO popupTextDataES;
    private string randomText;


    private float popupTimer = 0f;

    private void Start()
    {
        Locale currentSelectedLocale = LocalizationSettings.SelectedLocale;
        ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;
        if (currentSelectedLocale == availableLocales.GetLocale("en"))
        {
            textBox.text = popupTextDataEN.popupTexts[Random.Range(0, popupTextDataEN.popupTexts.Length)];
            randomText = popupTextDataEN.popupTexts[Random.Range(0, popupTextDataEN.popupTexts.Length)];
        }
        if (currentSelectedLocale == availableLocales.GetLocale("es"))
        {
            textBox.text = popupTextDataES.popupTexts[Random.Range(0, popupTextDataES.popupTexts.Length)];
            randomText = popupTextDataES.popupTexts[Random.Range(0, popupTextDataES.popupTexts.Length)];
        }        
    }

    private void Update()
    {
        popupTimer += Time.deltaTime;

        if (popupTimer >= popupDuration)
        {
            popupTimer = 0f;
            StartCoroutine(ShowPopupText(randomText));
        }
    }

    private IEnumerator ShowPopupText(string text)
    {
        textBox.text = text;
        yield return new WaitForSeconds(popupInterval);
    }
}
