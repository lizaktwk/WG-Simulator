using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject player;          // Reference to the player object
    [SerializeField] private Button leftArrowButton;     // Reference to the left arrow button
    [SerializeField] private Button rightArrowButton;    // Reference to the right arrow button
    [SerializeField] private float speed = 5.0f;         // Speed of the player's movement
    [SerializeField] private float moveDistance = 1.0f;  // Distance the player moves with each button press
    [SerializeField] private float minXPosition = -5.0f; // Minimum x position allowed
    [SerializeField] private float maxXPosition = 5.0f;  // Maximum x position allowed



    private Vector3 targetPosition; // Current target position of the player

    private void Awake()
    {
        // Initialize the player's starting position
        targetPosition = player.transform.position;
    }

    public void OnLeftArrowPress()
    {
        // Check if the player has reached the minimum x position
        if (targetPosition.x <= minXPosition)
        {
            leftArrowButton.interactable = false;
            return;
        }

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

        // Update the target position to move right
        targetPosition += Vector3.right * moveDistance;

        // Start the smooth movement coroutine
        StartCoroutine(SmoothMove());
    }

    private IEnumerator SmoothMove()
    {
        while (Vector3.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            float step = speed * Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, step);
            yield return null;
        }

        // Ensure the player snaps exactly to the target position
        player.transform.position = targetPosition;

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
