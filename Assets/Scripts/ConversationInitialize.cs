using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.EventSystems;

public class ConversationInitialize : MonoBehaviour
{
    public NPCConversation myConversation;

    // array of game objects that shall be set to inactive when having a conversation
    [SerializeField] private GameObject[] objectsToHide;

    public void startConversation()
    {
        Debug.Log("Conversation started");
        // Subscribe to the conversation end event
        ConversationManager.OnConversationEnded += OnConversationEnded;

        // Start the conversation
        ConversationManager.Instance.StartConversation(myConversation);

        // loop through the array of objects to hide and set them to inactive
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

        if (ConversationManager.Instance.GetBool("willHaveCoffee") == true)
        {
            SpawnManager.willHaveCoffee = true;
        }

    }

    private void OnDestroy()
    {
        // Ensure we unsubscribe from the event if the object is destroyed
        ConversationManager.OnConversationEnded -= OnConversationEnded;
        Debug.Log("Conversation ended");
    }



    
}

