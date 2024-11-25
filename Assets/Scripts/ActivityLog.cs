using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityLog
{
    // an array of strings to store the executed activities of the day
    private List<string> activities = new List<string>();


    public void AddActivity(string activity)
    {
        // Add the activity to the activities list
        activities.Add(activity);

        // send the activity list to the HappinessImpact script
        GameObject.Find("HappinessLevel").GetComponent<HappinessImpact>().getActivities(activities);

    }
}
