using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    [SerializeField] private GameObject phone; // Reference to the phone object

    [SerializeField] private GameObject phoneIcon; // Reference to the phone icon

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
        phone.transform.Find("Clock").gameObject.SetActive(true);

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
        Debug.Log("Profile button pressed");
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

        // make sure the clocks color is white
        phone.transform.Find("Clock").gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    public void OnStatsChanged()
    {
        // make the phone icon blink
        StartCoroutine(BlinkPhoneIcon());

    }

    private IEnumerator BlinkPhoneIcon()
    {
        // loop 5 times
        for (int i = 0; i < 5; i++)
        {

            yield return new WaitForSeconds(0.5f);
            // set the color of the phoneIcon to #00fff0
            phoneIcon.GetComponent<Image>().color = new Color(0, 1, 0.9411765f);

            // wait for 0.5 seconds
            yield return new WaitForSeconds(0.5f);

            // set the color of the phoneIcon to #FFCC00
            phoneIcon.GetComponent<Image>().color = new Color(1, 0.8f, 0);

            // wait for 0.5 seconds
            yield return new WaitForSeconds(0.5f);
        }
    }

}
