using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaHitTestMinimumThreshold : MonoBehaviour
{
    // The script ensures that the button is clickable only when the alpha value of the image is greater than 0.5.
    // So it prevents the button from being clicked when the rest of the image is transparent.

    public Image theButton;

    // Use this for initialization
    void Start()
    {
        theButton.alphaHitTestMinimumThreshold = 0.5f;
    }
}
