using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;  // Assign the player's Transform in the Inspector
    [SerializeField] private Vector3 offset;    // Offset for the camera's position
    [SerializeField] private float smoothSpeed = 0.125f; // Smoothness factor for following
    [SerializeField] private float fixedYPosition = 0f;  // Fixed Y value for the camera

    private void LateUpdate()
    {
        if (player != null)
        {
            // Follow X, maintain fixed Y, and Z positions
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, fixedYPosition + offset.y, offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

