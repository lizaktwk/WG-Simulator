using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BecomeVisible : MonoBehaviour
{
    public Light2D light2D; // Reference to the 2D Light
    public Camera playerCamera; // Reference to the player camera

    void Update()
    {
        if (IsVisibleToPlayerCamera())
        {
            // set light 2D to active
            light2D.gameObject.SetActive(true);
        }
        else
        {
            // set light 2D to inactive
            light2D.gameObject.SetActive(false);
        }
    }

    private bool IsVisibleToPlayerCamera()
    {
        if (playerCamera == null)
            return false;

        // Convert the object's position to viewport space
        Vector3 viewportPoint = playerCamera.WorldToViewportPoint(transform.position);

        // Check if the object is within the camera's viewport
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 &&
               viewportPoint.y >= 0 && viewportPoint.y <= 1 &&
               viewportPoint.z > 0; // Ensure it's in front of the camera
    }
}
