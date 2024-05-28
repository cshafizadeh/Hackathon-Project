using UnityEngine;

public class StartupManager : MonoBehaviour
{
    void Start()
    {
        // Hide the cursor and lock it to the center of the screen
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
