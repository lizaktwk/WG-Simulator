using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager: MonoBehaviour
{
    // This class is used to store the values of the stats, so the values are consistent across all scenes

    // Stats values to keep
    public static int energyValue = 450;
    public static int happinessValue = 120;

    public static int knowledgeValue = 30;
    public static int communicationValue = 30;
    public static int conflictresolvingValue = 30;
    public static int householdingValue = 30;

    public static int relationshipNoah = 30;
    public static int relationshipAnna = 30;
    public static int relationshipFelix = 30;

    public static bool willHaveCoffee = false;
    
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
