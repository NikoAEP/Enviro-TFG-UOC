using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;

public class TipsController : MonoBehaviour
{
    [SerializeField] private TMP_Text textBox; // caja de texto para los consejos
    [SerializeField] private float popupDuration = 15f; // duración del consejo
    [SerializeField] private float popupInterval = 1f; // intervalo entre consejos
    [SerializeField] private PopupTextSO popupTextDataEN; // textos en Inglés
    [SerializeField] private PopupTextSO popupTextDataES; // textos en Español
    private string randomText; // variable para guardar texto aleatorio

    private float popupTimer = 0f; // temporizador del popup

    private void Start()
    {
        Locale currentSelectedLocale = LocalizationSettings.SelectedLocale; // coge el idioma de localización actual
        ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales; // coge los idiomas disponibles
        if (currentSelectedLocale == availableLocales.GetLocale("en")) // si es inglés
        {
            // coge los textos en inglés
            textBox.text = popupTextDataEN.popupTexts[Random.Range(0, popupTextDataEN.popupTexts.Length)];
            randomText = popupTextDataEN.popupTexts[Random.Range(0, popupTextDataEN.popupTexts.Length)];
        }
        if (currentSelectedLocale == availableLocales.GetLocale("es")) // si es español
        {
            // coge los textos en español
            textBox.text = popupTextDataES.popupTexts[Random.Range(0, popupTextDataES.popupTexts.Length)];
            randomText = popupTextDataES.popupTexts[Random.Range(0, popupTextDataES.popupTexts.Length)];
        }        
    }

    private void Update()
    {
        popupTimer += Time.deltaTime; // se incrementa el temporizador

        if (popupTimer >= popupDuration) // si el temporizador llega a la duración
        {
            popupTimer = 0f; // se resetea el temporizador
            StartCoroutine(ShowPopupText(randomText)); // se muestra un texto aleatorio
        }
    }

    private IEnumerator ShowPopupText(string text)
    {
        textBox.text = text; // el texto que se pasa es el que se muestra
        yield return new WaitForSeconds(popupInterval); // se espera el intervalo seteado
    }
}
