using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InteractableButton))]
public class InteractableObject : MonoBehaviour, IPointerClickHandler
{
    private InteractableButton interactableButton; // Reference to the InteractableButton script

    private void Awake()
    {
        // Automatically find the InteractableButton component on the same GameObject
        interactableButton = GetComponent<InteractableButton>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Get the mouse click position
        Vector3 clickPosition = eventData.position;

        Debug.Log(gameObject.name + " clicked at screen position: " + clickPosition);

        // Convert the mouse click position to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);

        // Call the placeButton method from the InteractableButton script
        interactableButton.placeButton(worldPosition);
    }
}
