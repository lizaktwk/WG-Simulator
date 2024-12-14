using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAlternative : MonoBehaviour
{
    // attach this script to the UI manager object

    [SerializeField] private Camera camra;          // Reference to the player object
    //[SerializeField] private Camera mainCamera;          // Reference to the main camera
    [SerializeField] private Button leftArrowButton;     // Reference to the left arrow button
    [SerializeField] private Button rightArrowButton;    // Reference to the right arrow button
    [SerializeField] private float speed = 5.0f;         // Speed of the player's movement
    [SerializeField] private float moveDistance = 1.0f;  // Distance the player moves with each button press
    [SerializeField] private float minXPosition = -5.0f; // Minimum x position allowed
    [SerializeField] private float maxXPosition = 5.0f;  // Maximum x position allowed



    private Vector3 targetPosition; // Current target position of the player

    // Reference to the InteractionButton UI element
    private GameObject interactableButton;

    // reference to the conversationButton
    private GameObject conversationButton;

    private void Awake()
    {
        // Initialize the player's starting position
        targetPosition = camra.transform.position;
    }

    public void OnLeftArrowPress()
    {
        Debug.Log("Left Arrow Pressed");
        // Check if the player has reached the minimum x position
        if (targetPosition.x <= minXPosition)
        {
            leftArrowButton.interactable = false;
            return;
        }


        // find the interactionButton
        interactableButton = GameObject.Find("InteractionButton");
        // find the conversationButton
        conversationButton = GameObject.Find("ConversationButton");

        // check if there is an interactable button active
        if (interactableButton != null)
        {
            // set the interactable button to inactive
            interactableButton.gameObject.SetActive(false);
        }

        if (conversationButton != null)
        {
            // set the conversation button to inactive
            conversationButton.gameObject.SetActive(false);
        }

        // rotate the player's y axis to 180 degrees
        //player.transform.rotation = Quaternion.Euler(0, 180, 0);

        // Update the target position to move left
        targetPosition += Vector3.left * moveDistance;

        // Start the smooth movement coroutine
        StartCoroutine(SmoothMove());

    }

    public void OnRightArrowPress()
    {
        // Check if the player has reached the maximum x position
        if (targetPosition.x >= maxXPosition)
        {
            rightArrowButton.interactable = false;
            return;
        }


        // find the interactionButton
        interactableButton = GameObject.Find("InteractionButton");

        // find the conversationButton
        conversationButton = GameObject.Find("ConversationButton");

        // check if there is an interactable button active
        if (interactableButton != null)
        {
            // set the interactable button to inactive
            interactableButton.gameObject.SetActive(false);
        }

        if (conversationButton != null)
        {
            // set the conversation button to inactive
            conversationButton.gameObject.SetActive(false);
        }


        // rotate the player's y axis to 0 degrees
        //player.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Update the target position to move right
        targetPosition += Vector3.right * moveDistance;

        // Start the smooth movement coroutine
        StartCoroutine(SmoothMove());
    }

    private IEnumerator SmoothMove()
    {
        while (Vector3.Distance(camra.transform.position, targetPosition) > 0.01f)
        {
            float step = speed * Time.deltaTime;
            camra.transform.position = Vector3.MoveTowards(camra.transform.position, targetPosition, step);
            yield return null;
        }

        // Ensure the player snaps exactly to the target position
        camra.transform.position = targetPosition;

        // Enable or disable buttons based on position
        UpdateButtonInteractivity();
    }

    private void UpdateButtonInteractivity()
    {
        // Enable or disable the left arrow button
        leftArrowButton.interactable = targetPosition.x > minXPosition;

        // Enable or disable the right arrow button
        rightArrowButton.interactable = targetPosition.x < maxXPosition;
    }
}
