using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontakteApp : MonoBehaviour
{
    // reference to the game object that should be set to active when Kontakte is being pressed
    [SerializeField] private GameObject kontakteApp;
    // reference to the game objects that should be set to active when a specific contact is being pressed
    [SerializeField] private GameObject anna;


    public void OnKontaktePress()
    {
        // set the Kontakte app to active
        kontakteApp.SetActive(true);

        // set anna to inactive
        anna.SetActive(false);

    }

    public void OpenProfileAnna()
    {
        anna.SetActive(true);
    }

    public void CloseProfile()
    {
        anna.SetActive(false);
    }
}
