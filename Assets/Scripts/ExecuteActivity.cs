using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteActivity : MonoBehaviour
{
    // Get the EnergyLevel slider object from the scene
    public Slider energySlider;
    // Reference to the execution slider of the activity
    public Slider executionAnim;
    
    // variable to store the remaining energy value
    private float remainingEnergy;
   

    // This method will be called when the activity button is clicked
    public void OnButtonPress(string buttonText, string energyCost, Vector3 clickPos)
    {
        // get the current energy value from the slider
        float currentEnergy = energySlider.value;

        // Do something based on the button text
        if (buttonText == "Lernen")
        {
            // set the executionAnim slider to active
            executionAnim.gameObject.SetActive(true);
            // place the executionAnim slider at the click position
            executionAnim.transform.position = clickPos;
            // set the z position to 0 to ensure the slider is visible
            executionAnim.transform.position = new Vector3(executionAnim.transform.position.x, executionAnim.transform.position.y, 0);
            // Update the executionAnim slider value over time, as long as the energy slider takes to update
            StartCoroutine(ExecutionAnim());

            currentEnergy += float.Parse(energyCost);
            // Update the energy slider value over time
            StartCoroutine(UpdateEnergySlider(currentEnergy));
            // store the remaining energy value
            remainingEnergy = currentEnergy;
        }
        else if (buttonText == "Schlafen")
        {
            // set the executionAnim slider to active
            executionAnim.gameObject.SetActive(true);
            // place the executionAnim slider at the click position
            executionAnim.transform.position = clickPos;
            // set the z position to 0 to ensure the slider is visible
            executionAnim.transform.position = new Vector3(executionAnim.transform.position.x, executionAnim.transform.position.y, 0);
            // Update the executionAnim slider value over time, as long as the energy slider takes to update
            StartCoroutine(ExecutionAnim());

            currentEnergy += float.Parse(energyCost);
            // Update the energy slider value over time
            StartCoroutine(UpdateEnergySlider(currentEnergy));
            // store the remaining energy value
            remainingEnergy = currentEnergy;
        }

        else if (buttonText == "Sprechen")
        {
            // start the conversation with the NPC in the ConversationInitialize script
            GameObject.Find("Anna").GetComponent<ConversationInitialize>().startConversation();
        }

        else if (buttonText == "Kaffee trinken")
        {
            GameObject.Find("Anna").GetComponent<InitiateStoryActivity>().OnStoryActivityPress();
        }
       

        // send the executed activity to the ActivityLog
        ActivityLog.GetInstance().AddActivity(buttonText);

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
