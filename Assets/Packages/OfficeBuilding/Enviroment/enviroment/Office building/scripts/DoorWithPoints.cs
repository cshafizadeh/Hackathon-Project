using UnityEngine;

public class DoorWithPoints : MonoBehaviour
{
    public int pointsRequiredToOpen = 10; // Points required to open this door

    private Door doorScript;
    private PlayerPoints playerPoints;

    void Start()
    {
        doorScript = GetComponent<Door>();
        if (doorScript == null)
        {
            Debug.LogError("Door script not found on the door.");
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerPoints = player.GetComponent<PlayerPoints>();
        }

        if (playerPoints == null)
        {
            Debug.LogError("PlayerPoints script not found on the player.");
        }
    }

    public void TryOpenDoor()
    {
        if (playerPoints.totalPoints >= pointsRequiredToOpen)
        {
            doorScript.ActionDoor(); // Call the existing door functionality
        }
        else
        {
            Debug.Log("Not enough points to open the door. Points required: " + pointsRequiredToOpen);
        }
    }
}
