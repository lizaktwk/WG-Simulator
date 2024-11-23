using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    [SerializeField] private GameObject phone; // Reference to the phone object

    // array of game objects that shall be set to inactive when the phone is active
    [SerializeField] private GameObject[] objectsToHide;


    public void OnPhoneIconPress()
    {
        Debug.Log("Phone icon pressed");
        // set the phone object to active
        phone.SetActive(true);

        // loop through the array of objects to hide and set them to inactive
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }

    public void OnCloseButtonPress()
    {
        Debug.Log("Close button pressed");
        // set the phone object to inactive
        phone.SetActive(false);

        // loop through the array of objects to hide and set them to active
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(true);
        }
    }
}
