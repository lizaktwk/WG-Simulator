using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    // possible Game Objects that can be spawned
    [SerializeField] private GameObject[] objectsToSpawn;

    bool willHaveCoffee;
    private void Start()
    {
        SpawnObjectBasedOnTimeAndScene();
    }

    private void SpawnObjectBasedOnTimeAndScene()
    {
        // get the current time
        float currentTime = ClockManager.timeInHours;

        // get the current scene
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // if the current scene is "Scene1" and the current time is less than 10 seconds
        if (currentScene == "Corridor" && currentTime < 12.0f && currentTime > 7.5f)
        {
            // in the array of game objects, get the tag of the game objects
            foreach (GameObject obj in objectsToSpawn)
            {
                // if the tag of the game object is "Object1"
                if (obj.tag == "Anna")
                {
                    // instantiate the game object
                    obj.SetActive(true);
                }
            }            
        }
        else if (currentScene == "Kitchen" && currentTime < 12.0f && SpawnManager.willHaveCoffee == true)
        {
            foreach (GameObject obj in objectsToSpawn)
            {
                // if the tag of the game object is "Object1"
                if (obj.tag == "Anna")
                {
                    // instantiate the game object
                    obj.SetActive(true);
                }
            }
        }
    }
}
