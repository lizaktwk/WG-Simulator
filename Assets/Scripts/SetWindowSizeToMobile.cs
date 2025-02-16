using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWindowSizeToMobile : MonoBehaviour
{
    void Start()
    {
        // iPhone 12 Standardgröße in Punkten
        float targetWidth = 390f;
        float targetHeight = 844f;

        // Aktuelle Bildschirmauflösung abrufen
        float screenWidth = Screen.currentResolution.width;
        float screenHeight = Screen.currentResolution.height;

        // Skalierungsfaktor basierend auf Bildschirmhöhe
        float scaleFactor = screenHeight / targetHeight;

        // Neue Fenstergröße berechnen (proportional zur Monitorhöhe)
        int newWidth = Mathf.RoundToInt(targetWidth * scaleFactor);
        int newHeight = Mathf.RoundToInt(targetHeight * scaleFactor);

        // Fenstergröße setzen
        Screen.SetResolution(newWidth, newHeight, false);
    }
}
