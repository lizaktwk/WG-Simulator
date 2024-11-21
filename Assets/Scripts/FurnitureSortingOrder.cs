using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSortingOrder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject player;  // Reference to the player

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Adjust the sorting order based on the player's y position
        float playerY = player.transform.position.y;
        spriteRenderer.sortingOrder = Mathf.FloorToInt(playerY * 10) + 1;  // Ensure the furniture stays behind or in front
    }
}
