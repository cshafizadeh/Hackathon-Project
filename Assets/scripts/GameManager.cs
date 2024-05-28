using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int pointsNeeded = 100;
    void Start()
    {
        // Hide the cursor and lock it to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Check for a key press to unlock the cursor for debugging or exiting the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
