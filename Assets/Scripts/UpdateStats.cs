using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour
{
    // this script is used to keep the stats updated across all scenes. So it updates the scenes only when a new scene is loaded

    [SerializeField] private Slider energy;
    [SerializeField] private Slider happiness;

    [SerializeField] private Slider knowledgeSlider;
    [SerializeField] private Slider communicationSlider;
    [SerializeField] private Slider conflictSlider;
    [SerializeField] private Slider householdingSlider;

    [SerializeField] private Slider relationshipNoah;
    [SerializeField] private Slider relationshipAnna;
    [SerializeField] private Slider relationshipFelix;

    void Start()
    {
        int energyValue = StatsManager.energyValue;
        energy.value = energyValue;

        int happinessValue = StatsManager.happinessValue;
        happiness.value = happinessValue;

        int knowledgeValue = StatsManager.knowledgeValue;
        knowledgeSlider.value = knowledgeValue;

        int communicationValue = StatsManager.communicationValue;
        communicationSlider.value = communicationValue;

        int conflictValue = StatsManager.conflictresolvingValue;
        conflictSlider.value = conflictValue;

        int householdingValue = StatsManager.householdingValue;
        householdingSlider.value = householdingValue;

        int relationshipNoahValue = StatsManager.relationshipNoah;
        relationshipNoah.value = StatsManager.relationshipNoah;

        int relationshipAnnaValue = StatsManager.relationshipAnna;
        relationshipAnna.value = StatsManager.relationshipAnna;

        int relationshipFelixValue = StatsManager.relationshipFelix;
        relationshipFelix.value = StatsManager.relationshipFelix;
        
    }

}
