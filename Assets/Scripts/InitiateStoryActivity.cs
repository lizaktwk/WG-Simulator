using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitiateStoryActivity : MonoBehaviour
{
    // Reference to the GameObject that contains the story activity
    [SerializeField] private GameObject storyActivity;

    // Reference to the image component of the story activity
    [SerializeField] private Image storyActivityImage;

    // Reference to the Description Text of the story activity which is a textmeshpro object
    [SerializeField] private TextMeshProUGUI descriptionText;


    // reference to the continue button
    [SerializeField] private GameObject continueButton;

    // reference to the Impact GameObject
    [SerializeField] private GameObject impacts;

    // reference to the back to game button
    [SerializeField] private GameObject backToGameButton;

    // reference to the person that shall be set to inactive after pressing the return to game button
    [SerializeField] private GameObject person;

    public void OnStoryActivityPress()
    {
        // Set the story activity to active
        storyActivity.SetActive(true);
        // set the alpha value of the story activity to 0. The storyActivity gameobject is a UI Image, so we can access the color property
        storyActivity.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0);

        // set the children of the story activity to inactive
        foreach (Transform child in storyActivity.transform)
        {
            child.gameObject.SetActive(false);
        }

        // Call an Enumerator to fade in the story activity
        StartCoroutine(FadeInStoryActivity());
    }

    public void OnContinuePress()
    {
        // set the continue button to inactive
        continueButton.SetActive(false);
        // set the impacts of the story activity to active
        impacts.SetActive(true);
        // set the back to game button to active
        backToGameButton.SetActive(true);
    }

    public void BackToGame()
    {
        storyActivity.SetActive(false);
        // Disable the ShowActivity script attached to the person
        person.GetComponent<ShowActivity>().enabled = false;
        SpawnManager.willHaveCoffee = false;
    }

    IEnumerator FadeInStoryActivity()
    {
        // Get the color of the story activity
        Color color = storyActivity.GetComponent<UnityEngine.UI.Image>().color;

        // Fade in the story activity
        while (color.a < 1)
        {
            color.a += Time.deltaTime;
            storyActivity.GetComponent<UnityEngine.UI.Image>().color = color;
            yield return null;
        }

        // Set the image and description text to active every 2 seconds
        yield return new WaitForSeconds(1);
        storyActivityImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        descriptionText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        continueButton.SetActive(true);
    }
    
}
