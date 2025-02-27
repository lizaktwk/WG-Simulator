using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWindowSizeToMobile : MonoBehaviour
{
    void Start()
    {
        // Ursprüngliche Referenzauflösung des Canvas (1080x1920)
        float referenceWidth = 1080f;
        float referenceHeight = 1920f;

        // Aktuelle Fenstergröße abrufen
        float currentWidth = Screen.width;
        float currentHeight = Screen.height;

        // Skalierungsfaktor berechnen (auf Höhe basierend)
        float scaleFactor = currentHeight / referenceHeight;

        // Kamera-Orthographic Size dynamisch setzen
        Camera.main.orthographicSize = (referenceHeight / 2f) * scaleFactor;
    }
}
