using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSettings : MonoBehaviour
{
    void Start()
    {
        // Enable fog
        RenderSettings.fog = true;

        // Set fog mode to Linear
        RenderSettings.fogMode = FogMode.Linear;

        // Set fog color to a grayish color (you can change this to your desired color)
        RenderSettings.fogColor = new Color(0.69f, 0.69f, 0.69f); // equivalent to #B0B0B0

        // Set fog start and end distances
        RenderSettings.fogStartDistance = 1.0f;
        RenderSettings.fogEndDistance = 20.0f;
    }
}
