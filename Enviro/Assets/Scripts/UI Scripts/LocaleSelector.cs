using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private bool active = false; // falso por defecto

    private void Start()
    {
        int ID = PlayerPrefs.GetInt("LocaleKey", 0); // se coge la primera clave de Locale
        ChangeLocale(ID); // se cambia el idioma/locale según el ID pasado
    }

    public void ChangeLocale(int localeID)
    {
        if(active) // si esta activo
        {
            return; // se retorna
        }
        else
        {
            StartCoroutine(SetLocale(localeID)); // si no se cambia de idioma según el ID
        }
    }

    IEnumerator SetLocale(int _localeID)
    {
        active = true; 
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }
}
