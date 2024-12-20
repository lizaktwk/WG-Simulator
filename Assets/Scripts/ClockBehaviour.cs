using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockText;

    private Dictionary<string, float> activities = new Dictionary<string, float>
    {
        {"Schlafen", 8.0f},
        {"Lernen", 2.0f},
        {"Sprechen", 0.2f},
        {"Kaffee trinken", 0.5f}
    };

    void Start()
    {
        // Display the current time from ClockManager
        clockText.text = ClockManager.GetFormattedTime();
    }

    public void UpdateTime(string activity)
    {
        if (!activities.ContainsKey(activity))
        {
            Debug.LogWarning($"Activity '{activity}' not found.");
            return;
        }

        // Add the activity's time to ClockManager's time
        ClockManager.timeInHours += activities[activity];

        // Handle 24-hour rollover
        if (ClockManager.timeInHours >= 24.0f)
        {
            ClockManager.timeInHours -= 24.0f; // Wrap around to the next day
        }

        // Update the clock display
        clockText.text = ClockManager.GetFormattedTime();
    }
}
