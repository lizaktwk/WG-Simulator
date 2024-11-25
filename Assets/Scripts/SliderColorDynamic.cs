using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColorDynamic : MonoBehaviour
{
    // The script changes the color of the slider dynamically based on the value of the slider.
    // The color changes from red to green as the slider value changes from 0 to 100.
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private UnityEngine.UI.Image fillImage;


    // Start is called before the first frame update
    void Start()
    {
        // get the initial value of the slider and set the color of the fill image
        fillImage.color = Color.Lerp(Color.red, Color.green, slider.value / 100);

        //Adds a listener to the main slider and invokes a method when the value changes.
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        fillImage.color = Color.Lerp(Color.red, Color.green, slider.value / 100);
    }
}
