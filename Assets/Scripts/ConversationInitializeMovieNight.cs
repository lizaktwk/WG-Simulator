using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.EventSystems;

public class ConversationInitializeMovieNight : MonoBehaviour
{
    public NPCConversation myConversation;

    // Reference to the MovieNightImpacts script
    [SerializeField] private MovieNightImpacts movieNightImpacts;

    // array of game objects that shall be set to inactive when having a conversation
    [SerializeField] private GameObject[] objectsToHide;

    public void startConversation()
    {
        // Check if there is an active gameobject with the tag "StoryPicture" and set it to inactive
        GameObject storyPicture = GameObject.FindGameObjectWithTag("StoryPicture");
        if (storyPicture != null)
        {
            storyPicture.SetActive(false);
        }

        Debug.Log("Conversation started");

        // Prevent duplicate subscriptions
        ConversationManager.OnConversationEnded -= OnConversationEnded;
        ConversationManager.OnConversationEnded += OnConversationEnded;

        // Start the conversation
        ConversationManager.Instance.StartConversation(myConversation);

        // Loop through the array of objects to hide and set them to inactive
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }

    private void OnConversationEnded()
    {
        // loop through the array of objects to hide and set them to active
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(true);
        }

        if (ConversationManager.Instance.GetBool("allMovieNight") == true)
        {
            Debug.Log("All agreed on movie night");
            movieNightImpacts.agreeOnMovie();
        }

        else if (ConversationManager.Instance.GetBool("noahMovieNight") == true)
        {
            Debug.Log("Noah agreed on movie night");
            movieNightImpacts.movieWithNoah();
        }

        else if (ConversationManager.Instance.GetBool("aloneMovieNight") == true)
        {
            Debug.Log("Alone agreed on movie night");
            movieNightImpacts.movieAlone();
        }

        else if (ConversationManager.Instance.GetBool("leaveMovieNight") == true)
        {
            Debug.Log("Leaving the movie night");
            movieNightImpacts.leaveToRoom();
        }

    }

    private void OnDestroy()
    {
        // Ensure we unsubscribe from the event if the object is destroyed
        ConversationManager.OnConversationEnded -= OnConversationEnded;
        Debug.Log("Conversation ended");
    }
}
