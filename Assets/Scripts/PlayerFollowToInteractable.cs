using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowToInteractable : MonoBehaviour
{
    // The script needs to be attached to the game object that the player should follow to

    // added to move the player to the clicked position, could be removed
    [SerializeField] private GameObject player;     // Reference to the player object
    [SerializeField] private float playerSpeed = 0.1f; // Speed of the player's movement
    [SerializeField] private float offset = 0.5f;      // Offset for the player's x-position

    // function to move the player to the clicked position
    public void MovePlayerTo(Vector3 worldPosition)
    {
        // Move the player to the clicked position. z-position of the player remains the same. Also, the player should translate to the position over time
        Vector3 targetPosition = new Vector3(worldPosition.x + offset, player.transform.position.y, player.transform.position.z);
        StartCoroutine(MovePlayer(targetPosition));
    }


    // Coroutine to move the player to the target position
    private IEnumerator MovePlayer(Vector3 targetPosition)
    {
        if(player.transform.position.x < targetPosition.x)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        while (player.transform.position != targetPosition)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, playerSpeed);
            yield return null;
        }
    }
}
