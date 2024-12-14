using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderClickHandler : MonoBehaviour, IPointerClickHandler
{
    // Public LayerMask to filter layers for the raycast
    public LayerMask clickableLayer;

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null)
        {
            // Check if the clicked object is this one
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log($"Clicked on {gameObject.name}");
                // Trigger this object's event
                HandleClick();
            }
        }
    }

    private void HandleClick()
    {
        // Check which object was clicked
        Debug.Log("Clicked on this game object: " + gameObject.name);
    }
}
