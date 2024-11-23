using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableButton : MonoBehaviour
{
    [SerializeField] private Button button; // Reference to the button object
    public string buttonText; // Text to display on the button
    [SerializeField] private TextMeshProUGUI textComponent; // Reference to the TextMeshProUGUI for energy cost
    [SerializeField] private string energyCost; // Energy cost to display

    // Reference to the ExecuteActivity script
    [SerializeField] private ExecuteActivity executeActivity;

    public void placeButton(Vector3 clickPosition)
    {
        // Activate the button
        button.gameObject.SetActive(true);

        // Update the button's text
        var buttonTextComponent = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonTextComponent != null)
        {
            buttonTextComponent.text = buttonText;
        }
        else
        {
            Debug.LogWarning("No TextMeshProUGUI component found on button's child!");
        }

        // Update the energy cost display
        if (textComponent != null)
        {
            textComponent.text = energyCost;
        }
        else
        {
            Debug.LogWarning("No TextMeshProUGUI component assigned for energy cost!");
        }

        // Position the button at the interactable object's position
        button.transform.position = clickPosition;
        // set the z position to 0 to ensure the button is visible
        button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y, 0);

        // Add a listener to handle button click
        button.onClick.RemoveAllListeners(); // Remove any existing listeners
        button.onClick.AddListener(OnButtonClick);
    }

    // This method will be called when the button is clicked
    private void OnButtonClick()
    {
        if (executeActivity != null)
        {
            // Pass the button text to ExecuteActivity when the button is clicked
            executeActivity.OnButtonPress(buttonText);
        }
    }
}
