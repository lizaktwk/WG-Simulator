using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerOnClick : MonoBehaviour
{
    public float speed = 1.5f;
    private Vector3 target;

    // Boundary values
    public float xMin = -5f;      // Minimum x position (left boundary)
    public float xMax = 5f;       // Maximum x position (right boundary)
    public float yMin = -3f;      // Minimum y position (lower boundary)
    public float yMax = 3f;       // Maximum y position (upper boundary)

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the target position based on mouse click
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;  // Keep the z position unchanged

            // Prevent target from going beyond the boundaries
            target.x = Mathf.Clamp(target.x, xMin, xMax);  // Limit X axis movement
            target.y = Mathf.Clamp(target.y, yMin, yMax);  // Limit Y axis movement
        }

        // Move the player towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}