using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsImpact : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> impactsText = new List<TextMeshProUGUI>();
    [SerializeField] private List<Slider> stats = new List<Slider>();
    private List<int> impactValues = new List<int>();

    public void UpdateStatsAfterStory()
    {
        TextToInt();

        // Loop through all impactValues and match them with stats by tag
        for (int i = 0; i < impactValues.Count; i++)
        {
            for (int j = 0; j < stats.Count; j++)
            {
                if (stats[j].tag == impactsText[i].tag)
                {
                    //stats[j].value += impactValues[i];

                    if (stats[j].tag == "happiness")
                    {
                        StatsManager.happinessValue += impactValues[j];
                    }
                    else if (stats[j].tag == "knowledge")
                    {
                        StatsManager.knowledgeValue += impactValues[j];
                    }
                    else if (stats[j].tag == "communication")
                    {
                        StatsManager.communicationValue += impactValues[j];
                    }
                    else if (stats[j].tag == "conflictResolvement")
                    {
                        StatsManager.conflictresolvingValue += impactValues[j];
                    }
                    else if (stats[j].tag == "householding")
                    {
                        StatsManager.householdingValue += impactValues[j];
                    }
                    else if (stats[j].tag == "relationshipAnna")
                    {
                        StatsManager.relationshipAnna += impactValues[j];
                    }
                    else
                    {
                        Debug.LogError("No matching tag found for: " + impactsText[i].tag);
                    }
                }
            }
        }
    }

    private void TextToInt()
    {
        // Clear the list to prevent appending old values
        impactValues.Clear();

        foreach (TextMeshProUGUI impact in impactsText)
        {
            if (int.TryParse(impact.text, out int parsedValue))
            {
                impactValues.Add(parsedValue);
            }
            else
            {
                Debug.LogError("Failed to parse text into an integer: " + impact.text);
            }
        }
    }

    public void UpdateStatsImmediately()
    {

    }
}
