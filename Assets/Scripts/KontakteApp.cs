using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KontakteApp : MonoBehaviour
{
    // reference to the game object that should be set to active when Kontakte is being pressed
    [SerializeField] private GameObject kontakteApp;
    // reference to the game objects that should be set to active when a specific contact is being pressed
    [SerializeField] private GameObject noah;
    [SerializeField] private GameObject anna;
    [SerializeField] private GameObject felix;

    [SerializeField] private TextMeshProUGUI clock;

    public void OnKontaktePress()
    {
        // set the Kontakte app to active
        kontakteApp.SetActive(true);

        // set anna to inactive
        anna.SetActive(false);

        // change the text color of the clock to black
        clock.color = Color.black;


    }
    public void OpenProfileNoah()
    {
        noah.SetActive(true);
        clock.color = Color.white;
    }

    public void OpenProfileAnna()
    {
        anna.SetActive(true);
        clock.color = Color.white;
    }

    public void OpenProfileFelix()
    {
        felix.SetActive(true);
        clock.color = Color.white;
    }

    public void CloseProfile()
    {
        noah.SetActive(false);
        anna.SetActive(false);
        felix.SetActive(false);
        clock.color = Color.black;
    }
}
