using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    [SerializeField] private GameObject phone; // Reference to the phone object

    // array of game objects that shall be set to inactive when the phone is active
    [SerializeField] private GameObject[] objectsToHide;

    // reference to the button for the profile app
    //[SerializeField] private Button profilButton;
    [SerializeField] private GameObject profilApp;

    // reference to the button for the todo app
    //[SerializeField] private Button todoButton;
    [SerializeField] private GameObject todoApp;




    public void OnPhoneIconPress()
    {
        Debug.Log("Phone icon pressed");
        // set the phone object to active
        phone.SetActive(true);

        // find the phone's child with the name "Homescreen" and set it to active
        phone.transform.Find("Homescreen").gameObject.SetActive(true);
        phone.transform.Find("CloseButton").gameObject.SetActive(true);

        // loop through the array of objects to hide and set them to inactive
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }

    public void OnCloseButtonPress()
    {
        // set the phone object to inactive
        phone.SetActive(false);

        // loop through the array of objects to hide and set them to active
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(true);
        }

        // get the phone's children and set them to inactive
        foreach (Transform child in phone.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void OnProfilButtonPress()
    {
        // set the profile app to active
        profilApp.SetActive(true);
    }

    public void OnTodoButtonPress()
    {
        // set the profile app to active
        todoApp.SetActive(true);
    }

    public void OnHomeButtonPress()
    {
        // set all game objects with the tag "app" to inactive
        GameObject[] apps = GameObject.FindGameObjectsWithTag("app");
        foreach (GameObject app in apps)
        {
            app.SetActive(false);
        }
    }

}
