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
        print("The current difficulty is " + currentDifficulty);
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
        print("The current pollution is less than or equal to the current difficulty:" + (pollution <= difficulty));
        return (pollution <= difficulty);
    }
}
