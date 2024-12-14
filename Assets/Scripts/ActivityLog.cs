using System.Collections.Generic;
using UnityEngine;

public class ActivityLog : MonoBehaviour
{
    public static ActivityLog Instance { get; private set; }

    private List<string> activities = new List<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    public static ActivityLog GetInstance()
    {
        // If Instance is null, create a new GameObject and add the ActivityLog component
        if (Instance == null)
        {
            GameObject obj = new GameObject("ActivityLogManager");
            Instance = obj.AddComponent<ActivityLog>();
        }
        return Instance;
    }

    public void AddActivity(string activity)
    {
        activities.Add(activity);
        Debug.Log("all activities so far: " + string.Join(", ", activities));
    }

    public List<string> GetActivities()
    {
        return new List<string>(activities);
    }
}
