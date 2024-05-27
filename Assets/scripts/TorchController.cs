using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    private Light torchLight;

    // Start is called before the first frame update
    void Start()
    {
        torchLight = GetComponentInChildren<Light>();
        torchLight.enabled = false; // Start with the torch off
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // Use the 'T' key to toggle the torch
        {
            torchLight.enabled = !torchLight.enabled;
        }
    }
}
