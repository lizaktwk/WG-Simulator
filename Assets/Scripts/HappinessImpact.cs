using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HappinessImpact : MonoBehaviour
{
    // default happiness values for the activities
    private Dictionary<string, int> defaultValues = new Dictionary<string, int>
    {
        { "Lernen", 20 },
        { "Schlafen", 220 },
        { "Cooking", 2 },
        { "Gaming", 1 },
        { "Sleeping", 4 },
        { "Kaffee trinken", 0 } // its a story activity with a flatmate. So the happiness impact is handled by the StoryStatsImpact script
    };

    // an array of strings to store the executed activities of the day
    private List<string> activities = new List<string>();

    [SerializeField] private Slider happinessSlider;
    // variable to store the current happiness value
    private float currentHappiness;
    // variable to store the remaining energy value
    private float remainingHappiness;



    public void getActivities(List<string> activities)
    {
        // get the current happiness value from the slider
        currentHappiness = happinessSlider.value;

        // Add the activity to the activities list
        this.activities = activities;

        // calculate the happiness impact of the activities
        CalculateHappinessImpact();


    }

    private void CalculateHappinessImpact()
    {
        if (activities.Last() == "Lernen")
        {
            int lernenValue = defaultValues["Lernen"];
            // count the amount of "Lernen" activities
            int count = activities.FindAll(x => x == "Lernen").Count;
            
            if (count == 1)
            {
                currentHappiness += lernenValue;
                // Update the happiness slider value over time
                StartCoroutine(UpdateHappinessSlider(currentHappiness));
                // store the remaining energy value
                remainingHappiness = currentHappiness;
            }

           else if(count == 2)
            {
                currentHappiness += lernenValue-10;
                // Update the happiness slider value over time
                StartCoroutine(UpdateHappinessSlider(currentHappiness));
                // store the remaining energy value
                remainingHappiness = currentHappiness;
            }

            else if (count == 3)
            {
                currentHappiness += lernenValue - 15;
                // Update the happiness slider value over time
                StartCoroutine(UpdateHappinessSlider(currentHappiness));
                // store the remaining energy value
                remainingHappiness = currentHappiness;
            }

            else
            {
                currentHappiness -= lernenValue-10;
                // Update the happiness slider value over time
                StartCoroutine(UpdateHappinessSlider(currentHappiness));
                // store the remaining energy value
                remainingHappiness = currentHappiness;
            }

        }


        if (activities.Last() == "Schlafen")
        {
            int schlafenValue = defaultValues["Schlafen"];
            // count the amount of "Schlafen" activities
            //int count = activities.FindAll(x => x == "Schlafen").Count;

            currentHappiness += schlafenValue;
            // Update the happiness slider value over time
            StartCoroutine(UpdateHappinessSlider(currentHappiness));
            // store the remaining energy value
            remainingHappiness = currentHappiness;

            //if (count == 1)
            //{
                
            //}
        }

        if (activities.Last() == "Kaffee trinken")
        {
            int kaffeeValue = defaultValues["Kaffee trinken"];

            currentHappiness += kaffeeValue;
            // Update the happiness slider value over time
            StartCoroutine(UpdateHappinessSlider(currentHappiness));
            // store the remaining energy value
            remainingHappiness = currentHappiness;


        }


        else
        {
        }
        Debug.Log("Happinessimpact script was called");

        // Store the remaining happiness value by sending it to the StatsManager script
        StatsManager.happinessValue = (int)remainingHappiness;
    }

    // Coroutine to update the happiness slider value over time
    IEnumerator UpdateHappinessSlider(float targetValue)
    {
        
            float duration = 2f; // Duration of the animation in seconds
            float elapsedTime = 0f; // Elapsed time since the animation started

            float startValue = happinessSlider.value; // Initial value of the slider

            while (elapsedTime < duration)
            {
                // Increment the elapsed time
                elapsedTime += Time.deltaTime;

                // Calculate the new value based on the current time
                float newValue = Mathf.Lerp(startValue, targetValue, elapsedTime / duration);

                // Update the slider value
                happinessSlider.value = newValue;

                // Wait for the next frame
                yield return null;
            }

            // Ensure the slider value is set to the target value
            happinessSlider.value = targetValue;
       
        
    }
}
