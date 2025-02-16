using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteActivity : MonoBehaviour
{
    // this script is attached to the UI Manager object and is used to execute the activities

    // Get the EnergyLevel slider object from the scene
    public Slider energySlider;
    public Slider knowledgeSlider;
    public Slider communicationSlider;
    public Slider conflictSlider;
    public Slider householdingSlider;
    public Slider relationshipAnna;
    // Reference to the execution slider of the activity
    public Slider executionAnim;
    
    // Reference to the HappinessImpact script
    public HappinessImpact happinessImpact;

    // variable to store the remaining energy and happiness value
    private float remainingEnergy;

   

    // This method will be called when the activity button is clicked. It shall only call the executionAnim
    public void OnButtonPress(string buttonText, string energyCost, Vector3 clickPos)
    {
        // get the current values from the sliders by calling the StatsManager script
        int energyValue = StatsManager.energyValue;
        int happinessValue = StatsManager.happinessValue;
        int knowledgeValue = StatsManager.knowledgeValue;
        int communicationValue = StatsManager.communicationValue;
        int conflictValue = StatsManager.conflictresolvingValue;
        int householdingValue = StatsManager.householdingValue;
        int relationshipValue = StatsManager.relationshipAnna;


        // Do something based on the button text
        if (buttonText == "Lernen")
        {
            // Handle the visual execution of the activity
            // set the executionAnim slider to active
            executionAnim.gameObject.SetActive(true);
            // place the executionAnim slider at the click position
            executionAnim.transform.position = clickPos;
            // set the z position to 0 to ensure the slider is visible
            executionAnim.transform.position = new Vector3(executionAnim.transform.position.x, executionAnim.transform.position.y, 0);
            // Update the executionAnim slider value over time, as long as the energy slider takes to update
            StartCoroutine(ExecutionAnim());

            // handle the energy cost of the activity. since the energyvalue is set in the inspector, we can just add the energy cost to the energy value
            energyValue += int.Parse(energyCost);
            // Update the energy slider value over time
            StartCoroutine(UpdateEnergySlider(energyValue));
            // store the remaining energy value
            remainingEnergy = energyValue;

            // handle the profile stats impact of the activity
            StatsManager.knowledgeValue += 10;
            knowledgeSlider.value = StatsManager.knowledgeValue;

        }
        else if (buttonText == "Schlafen")
        {
            // Handle the visual execution of the activity
            // set the executionAnim slider to active
            executionAnim.gameObject.SetActive(true);
            // place the executionAnim slider at the click position
            executionAnim.transform.position = clickPos;
            // set the z position to 0 to ensure the slider is visible
            executionAnim.transform.position = new Vector3(executionAnim.transform.position.x, executionAnim.transform.position.y, 0);
            // Update the executionAnim slider value over time, as long as the energy slider takes to update
            StartCoroutine(ExecutionAnim());


            energyValue += int.Parse(energyCost);
            StartCoroutine(UpdateEnergySlider(energyValue));
            // store the remaining energy value
            remainingEnergy = energyValue;
        }

        else if (buttonText == "Sprechen")
        {  
            // start the conversation with the NPC in the ConversationInitialize script
            GameObject.Find("Anna").GetComponent<ConversationInitialize>().startConversation();

            energyValue += int.Parse(energyCost);
            StartCoroutine(UpdateEnergySlider(energyValue));
            // store the remaining energy value
            remainingEnergy = energyValue;
        }

        else if (buttonText == "Kaffee trinken")
        {
            GameObject.Find("Anna").GetComponent<InitiateStoryActivity>().OnStoryActivityPress();
            energyValue += int.Parse(energyCost);
            StartCoroutine(UpdateEnergySlider(energyValue));
            remainingEnergy = energyValue;
        }

        else if (buttonText == "Filmabend")
        {
            GameObject.Find("Noah").GetComponent<InitiateStoryActivity>().OnStoryActivityPress();
            energyValue += 0;
            StartCoroutine(UpdateEnergySlider(energyValue));
            remainingEnergy = energyValue;
        }
       

        // send the executed activity to the ActivityLog
        ActivityLog.GetInstance().AddActivity(buttonText);

        // call the HappinessImpact script to calculate the happiness impact of the executed activity
        happinessImpact.getActivities(ActivityLog.GetInstance().GetActivities());

        // keep the energy value consistent across all scenes
        StatsManager.energyValue = (int)remainingEnergy;
    }

    // Coroutine to update the energy slider value over time
    IEnumerator UpdateEnergySlider(float targetValue)
    {
        float duration = 2f; // Duration of the animation in seconds
        float elapsedTime = 0f; // Elapsed time since the animation started

        float startValue = energySlider.value; // Initial value of the slider

        while (elapsedTime < duration)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the new value based on the current time
            float newValue = Mathf.Lerp(startValue, targetValue, elapsedTime / duration);

            // Update the slider value
            energySlider.value = newValue;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the slider value is set to the target value
        energySlider.value = targetValue;
        remainingEnergy = targetValue;
    }

    // Coroutine to update the energy slider value over time
    //IEnumerator UpdateHappinessSlider(float targetValue)
    //{
    //    float duration = 2f; // Duration of the animation in seconds
    //    float elapsedTime = 0f; // Elapsed time since the animation started

    //    float startValue = energySlider.value; // Initial value of the slider

    //    while (elapsedTime < duration)
    //    {
    //        // Increment the elapsed time
    //        elapsedTime += Time.deltaTime;

    //        // Calculate the new value based on the current time
    //        float newValue = Mathf.Lerp(startValue, targetValue, elapsedTime / duration);

    //        // Update the slider value
    //        happinessSlider.value = newValue;

    //        // Wait for the next frame
    //        yield return null;
    //    }

    //    // Ensure the slider value is set to the target value
    //    happinessSlider.value = targetValue;
    //    remainingHappiness = targetValue;
    //}

    IEnumerator ExecutionAnim()
    {
        float duration = 2f; // Duration of the animation in seconds
        float elapsedTime = 0f; // Elapsed time since the animation started

        float startValue = executionAnim.minValue; // Initial value of the slider
        float maxValue = executionAnim.maxValue; // End value of the slider

        while (elapsedTime < duration)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the new value based on the current time
            float newValue = Mathf.Lerp(startValue, maxValue, elapsedTime / duration);

            // Update the slider value
            executionAnim.value = newValue;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the slider value is set to the target value
        executionAnim.value = maxValue;

        // Deactivate the executionAnim slider
        executionAnim.gameObject.SetActive(false);

    }
}
