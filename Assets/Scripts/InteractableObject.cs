using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(InteractableButton))]
public class InteractableObject : MonoBehaviour, IPointerClickHandler
{
    private InteractableButton interactableButton; // Reference to the ShowPossibleActivity script
    

    private void Awake()
    {
        // Automatically find the InteractableButton component on the same GameObject
        interactableButton = GetComponent<InteractableButton>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Get the mouse click position
        Vector3 clickPosition = eventData.position;

        // Convert the mouse click position to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);

        // Call the placeButton method from the ShowPossibleActivity script
        interactableButton.placeButton(worldPosition);

        // Move the player to the clicked position. Therefore, call the MovePlayerTo method from the PlayerFollowToInteractable script
        FindObjectOfType<PlayerFollowToInteractable>().MovePlayerTo(worldPosition);


    }

}
