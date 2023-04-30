using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollutionUI : MonoBehaviour
{
    [SerializeField] private Image[] pollutionLevel;
    private int currentDifficulty;
    void Start()
    {
        currentDifficulty = GameManager.instance.difficulty;
    }

    void Update()
    {
        PollutionBarFiller();
    }
    
    void PollutionBarFiller()
    {
        for(int i = 0; i < pollutionLevel.Length; i++)
        {
            pollutionLevel[i].enabled = DisplayPollutionLevel(currentDifficulty, i);
        }
    }

    bool DisplayPollutionLevel(int difficulty, int pollution)
    {
        return (pollution <= difficulty);
    }
}
