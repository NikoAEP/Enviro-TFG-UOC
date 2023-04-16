
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer; // el mezclador principal

    public void SetDifficulty(int index) // setea la dificultad según la elección del dropdown
    {
        GameManager.instance.difficulty = index;
    }

    public void SetVolume(float volume) // setea el volumen del mezclador
    {
        mainMixer.SetFloat("volume", volume);
    }
}
