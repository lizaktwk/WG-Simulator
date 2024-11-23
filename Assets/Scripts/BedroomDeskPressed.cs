using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BedroomDeskPressed : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        // get the mouse click position
        Vector3 clickPosition = eventData.position;

        Debug.Log("Bedroom desk pressed at position: " + clickPosition);

        // convert the mouse click position to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        

        // Call the placeButton method from the InteractableButton script
        GetComponent<InteractableButton>().placeButton(worldPosition);
    }
}
