using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    public int totalPoints = 0;
    public Text pointsText;

    void Start()
    {
        UpdatePointsText();
    }

    public void AddPoints(int points)
    {
        totalPoints += points;
        UpdatePointsText();
    }

    void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + totalPoints;
        }
    }
}
