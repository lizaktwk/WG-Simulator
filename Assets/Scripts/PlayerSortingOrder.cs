using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSortingOrder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Adjust the sorting order based on the player's y position
        spriteRenderer.sortingOrder = Mathf.FloorToInt(transform.position.y);
    }
}