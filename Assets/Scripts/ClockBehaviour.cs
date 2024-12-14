using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ClockBehaviour : MonoBehaviour
{
    // This script is attached to the Clock object in the scene

    // get the clock text object
    [SerializeField] private TextMeshProUGUI clockText;
    float elapsedTime = 0;


    // a list of activities and their time consumption values
    private Dictionary<string, float> activities = new Dictionary<string, float>
    {
        {"Schlafen", 8.0f},
        {"Lernen", 2f},
        {"Sprechen", 0f }
    };

    // Start is called before the first frame update
    void Start()
    {
        // set the clock to 8:00
        clockText.text = "8:00";        
    }

    // a function that updates the clock time based on the time consumption of the activity
    public void UpdateTime(string activity)
    {
        elapsedTime += activities[activity];
        int hours = 8 + (int)elapsedTime;
        int minutes = (int)((elapsedTime - (int)elapsedTime) * 60);
        clockText.text = hours.ToString() + ":" + minutes.ToString("00");

        // if the time is past 23:59, reset the clock to 0:00
        if (hours >= 24)
        {
            elapsedTime = 0;
            clockText.text = "0:00";
        }

    }

    
}
