using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryStatsImpact : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> impactsText = new List<TextMeshProUGUI>();
    [SerializeField] private List<Slider> stats = new List<Slider>();
    private List<int> impactValues = new List<int>();

    public void UpdateStatsAfterStory()
    {
        TextToInt();

        // Loop through all impactValues and match them with stats by tag
        for (int i = 0; i < impactsText.Count; i++)
        {
            string tag = impactsText[i].tag;
            int impactValue = impactValues[i];
            bool tagFound = false;

            // Search for the corresponding stat by tag
            foreach (Slider stat in stats)
            {
                if (stat.tag == tag)
                {
                    tagFound = true;

                    // Update StatsManager based on the tag
                    switch (tag)
                    {
                        case "happiness":
                            StatsManager.happinessValue += impactValue;
                            break;
                        case "knowledge":
                            StatsManager.knowledgeValue += impactValue;
                            break;
                        case "communication":
                            StatsManager.communicationValue += impactValue;
                            break;
                        case "conflictresolvement":
                            StatsManager.conflictresolvingValue += impactValue;
                            break;
                        case "householding":
                            StatsManager.householdingValue += impactValue;
                            break;
                        case "relationshipNoah":
                            StatsManager.relationshipNoah += impactValue;
                            break;
                        case "relationshipAnna":
                            StatsManager.relationshipAnna += impactValue;
                            break;
                        case "relationshipFelix":
                            StatsManager.relationshipFelix += impactValue;
                            break;
                        case "relationshipAll":
                            StatsManager.relationshipNoah += impactValue;
                            StatsManager.relationshipAnna += impactValue;
                            StatsManager.relationshipFelix += impactValue;
                            break;
                        default:
                            Debug.LogError($"Unhandled tag: {tag}");
                            break;
                    }

                    // Optionally update the slider value
                    stat.value += impactValue;
                    break; // Break from stats loop once a match is found
                }
            }

            if (!tagFound)
            {
                Debug.LogWarning($"No matching stat found for tag: {tag}. Impact value ({impactValue}) ignored.");
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

}
