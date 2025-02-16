using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWindowSizeToMobile : MonoBehaviour
{
    void Start()
    {
        // iPhone 12 Standardgr��e in Punkten
        float targetWidth = 390f;
        float targetHeight = 844f;

        // Aktuelle Bildschirmaufl�sung abrufen
        float screenWidth = Screen.currentResolution.width;
        float screenHeight = Screen.currentResolution.height;

        // Skalierungsfaktor basierend auf Bildschirmh�he
        float scaleFactor = screenHeight / targetHeight;

        // Neue Fenstergr��e berechnen (proportional zur Monitorh�he)
        int newWidth = Mathf.RoundToInt(targetWidth * scaleFactor);
        int newHeight = Mathf.RoundToInt(targetHeight * scaleFactor);

        // Fenstergr��e setzen
        Screen.SetResolution(newWidth, newHeight, false);
    }
}
