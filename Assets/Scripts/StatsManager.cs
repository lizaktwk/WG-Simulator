using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager: MonoBehaviour
{
    // This class is used to store and set the values of the stats, so the values are consistent across all scenes

    // Stats values to keep
    public static int energyValue;
    public static int happinessValue;

    public static int knowledgeValue;
    public static int communicationValue;
    public static int conflictresolvingValue;
    public static int householdingValue;

    public static int relationshipAnna;

    public static StatsManager Instance;

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
}
