using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour
{
    [SerializeField] private Slider energy;
    [SerializeField] private Slider happiness;

    [SerializeField] private Slider knowledgeSlider;
    [SerializeField] private Slider communicationSlider;
    [SerializeField] private Slider conflictSlider;
    [SerializeField] private Slider householdingSlider;

    [SerializeField] private Slider relationshipAnna;

    // Start is called before the first frame update
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

        int relationshipValue = StatsManager.relationshipAnna;
        relationshipAnna.value = StatsManager.relationshipAnna;
        
    }

}