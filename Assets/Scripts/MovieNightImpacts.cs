using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MovieNightImpacts : MonoBehaviour
{
    // Reference to the GameObject that contains the story activity
    [SerializeField] private GameObject storyActivityAll;
    [SerializeField] private Image storyActivityImageAll;
    [SerializeField] private TextMeshProUGUI descriptionAll;
    [SerializeField] private GameObject continueButtonAll;
    [SerializeField] private GameObject impactsAll;
    [SerializeField] private GameObject backToGameButtonAll;


    [SerializeField] private GameObject storyActivityNoah;
    [SerializeField] private Image storyActivityImageNoah;
    [SerializeField] private TextMeshProUGUI descriptionNoah;
    [SerializeField] private GameObject continueButtonNoah;
    [SerializeField] private GameObject impactsNoah;
    [SerializeField] private GameObject backToGameButtonNoah;


    [SerializeField] private GameObject storyActivityAlone;
    [SerializeField] private Image storyActivityImageAlone;
    [SerializeField] private TextMeshProUGUI descriptionAlone;
    [SerializeField] private GameObject continueButtonAlone;
    [SerializeField] private GameObject impactsAlone;
    [SerializeField] private GameObject backToGameButtonAlone;

    [SerializeField] private GameObject storyActivityLeave;
    [SerializeField] private Image storyActivityImageLeave;
    [SerializeField] private TextMeshProUGUI descriptionLeave;
    [SerializeField] private GameObject continueButtonLeave;
    [SerializeField] private GameObject impactsLeave;
    [SerializeField] private GameObject backToGameButtonLeave;

    // reference to the person that shall be set to inactive after pressing the return to game button
    //[SerializeField] private GameObject person;

    private GameObject storyActivity;
    private Image storyActivityImage;
    private TextMeshProUGUI descriptionText;
    private GameObject continueButton;
    private GameObject impacts;
    private GameObject backToGameButton;


    public void agreeOnMovie()
    {
        // Set the story activity to active
        storyActivityAll.SetActive(true);
        // set the alpha value of the story activity to 0. The storyActivity gameobject is a UI Image, so we can access the color property
        storyActivityAll.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0);

        // set the children of the story activity to inactive
        foreach (Transform child in storyActivityAll.transform)
        {
            child.gameObject.SetActive(false);
        }

        storyActivity = storyActivityAll;
        storyActivityImage = storyActivityImageAll;
        descriptionText = descriptionAll;
        continueButton = continueButtonAll;
        impacts = impactsAll;
        backToGameButton = backToGameButtonAll;
        // Call an Enumerator to fade in the story activity
        StartCoroutine(FadeInStoryActivity());
    }

    public void movieWithNoah()
    {
        // Set the story activity to active
        storyActivityNoah.SetActive(true);
        // set the alpha value of the story activity to 0. The storyActivity gameobject is a UI Image, so we can access the color property
        storyActivityNoah.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0);

        // set the children of the story activity to inactive
        foreach (Transform child in storyActivityNoah.transform)
        {
            child.gameObject.SetActive(false);
        }

        storyActivity = storyActivityNoah;
        storyActivityImage = storyActivityImageNoah;
        descriptionText = descriptionNoah;
        continueButton = continueButtonNoah;
        impacts = impactsNoah;
        backToGameButton = backToGameButtonNoah;
        // Call an Enumerator to fade in the story activity
        StartCoroutine(FadeInStoryActivity());
    }

    public void movieAlone()
    {
        // Set the story activity to active
        storyActivityAlone.SetActive(true);
        // set the alpha value of the story activity to 0. The storyActivity gameobject is a UI Image, so we can access the color property
        storyActivityAlone.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0);

        // set the children of the story activity to inactive
        foreach (Transform child in storyActivityAlone.transform)
        {
            child.gameObject.SetActive(false);
        }

        storyActivity = storyActivityAlone;
        storyActivityImage = storyActivityImageAlone;
        descriptionText = descriptionAlone;
        continueButton = continueButtonAlone;
        impacts = impactsAlone;
        backToGameButton = backToGameButtonAlone;
        // Call an Enumerator to fade in the story activity
        StartCoroutine(FadeInStoryActivity());
    }

    public void leaveToRoom()
    {
        // Set the story activity to active
        storyActivityLeave.SetActive(true);
        // set the alpha value of the story activity to 0. The storyActivity gameobject is a UI Image, so we can access the color property
        storyActivityLeave.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0);

        // set the children of the story activity to inactive
        foreach (Transform child in storyActivityLeave.transform)
        {
            child.gameObject.SetActive(false);
        }

        storyActivity = storyActivityLeave;
        storyActivityImage = storyActivityImageLeave;
        descriptionText = descriptionLeave;
        continueButton = continueButtonLeave;
        impacts = impactsLeave;
        backToGameButton = backToGameButtonLeave;
        // Call an Enumerator to fade in the story activity
        StartCoroutine(FadeInStoryActivity());



        // load the bedroom scene
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Bedroom");
    }

    public void OnContinuePress() {
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
        
        // if the story activity is storyActivityLeave, load the bedroom scene
        if (storyActivity == storyActivityLeave)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Bedroom");
        }
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
