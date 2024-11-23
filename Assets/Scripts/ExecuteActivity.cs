using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteActivity : MonoBehaviour
{
    // Reference to the InteractableButton script
    private InteractableButton interactableButton;

    // Start is called before the first frame update
    void Start()
    {
        // Get the InteractableButton script attached to the GameObject
        interactableButton = GetComponent<InteractableButton>();
    }

    // This method will be called when the button is clicked
    public void OnButtonPress(string buttonText)
    {
        // Do something based on the button text
        if (buttonText == "Lernen")
        {
            Debug.Log("Lernen button pressed");
        }
        else
        {
            Debug.Log("Button pressed: " + buttonText);
        }
    }
}
