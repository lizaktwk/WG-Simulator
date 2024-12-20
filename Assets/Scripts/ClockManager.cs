using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{
    public static float timeInHours = 8.0f; // 8.5 = 8:30
    public static ClockManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Helper function to get the time as a formatted string (e.g., "9:00")
    public static string GetFormattedTime()
    {
        int hours = (int)timeInHours;
        int minutes = (int)((timeInHours - hours) * 60);
        return $"{hours}:{minutes:00}";
    }
}
