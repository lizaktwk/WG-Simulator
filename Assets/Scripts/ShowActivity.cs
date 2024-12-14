using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowActivity : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Button interactionButton; // Reference to the button object
    public string activity; // Text to display on the button
    [SerializeField] private TextMeshProUGUI textComponent; // Reference to the TextMeshProUGUI for energy cost
    [SerializeField] private string energyCost; // Energy cost to display

    [SerializeField] private ExecuteActivity executeActivity; // Reference to the ExecuteActivity script

    [SerializeField] private ClockBehaviour clockBehaviour; // Reference to the ClockBehaviour script

    private Vector3 storedClickPos; // Position of the click

    // method to handle the click on the interactable object
    public void OnPointerClick(PointerEventData eventData)
    {
        // Get the mouse click position
        Vector3 clickPosition = eventData.position;

        // Convert the mouse click position to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);

        // Call placeButton method
        placeButton(worldPosition);

        // Move the player to the clicked position. Therefore, call the MovePlayerTo method from the PlayerFollowToInteractable script
        FindObjectOfType<PlayerFollowToInteractable>().MovePlayerTo(worldPosition);
    }

    public void placeButton(Vector3 clickPosition)
    {
        // Store the click position
        storedClickPos = clickPosition;

        // Activate the button
        interactionButton.gameObject.SetActive(true);

        // Update the button's text
        var buttonTextComponent = interactionButton.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonTextComponent != null)
        {
            buttonTextComponent.text = activity;
        }
        else
        {
            Debug.LogWarning("No TextMeshProUGUI component found on button's child!");
        }

        // Update the energy cost display
        if (textComponent != null)
        {
            textComponent.text = energyCost;
        }
        else
        {
            Debug.LogWarning("No TextMeshProUGUI component assigned for energy cost!");
        }

        // Position the button at the interactable object's position
        interactionButton.transform.position = clickPosition;
        // set the z position to 0 to ensure the button is visible
        interactionButton.transform.position = new Vector3(interactionButton.transform.position.x, interactionButton.transform.position.y, 0);

        // Add a listener to handle button click
        interactionButton.onClick.RemoveAllListeners(); // Remove any existing listeners
        interactionButton.onClick.AddListener(OnActivityClick);
    }

    // This method will be called when the button is clicked
    private void OnActivityClick()
    {
        if (executeActivity != null)
        {
            // Deactivate the button
            interactionButton.gameObject.SetActive(false);
            // Pass the button text to ExecuteActivity when the button is clicked
            executeActivity.OnButtonPress(activity, energyCost, storedClickPos);
            // Update the clock time based on the activity
            clockBehaviour.UpdateTime(activity);
        }
    }
}
