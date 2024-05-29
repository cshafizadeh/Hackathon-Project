using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Name of the game scene
    public string gameSceneName = "GameScene"; // Replace with the name of your game scene
    public string homeSceneName = "Startup";

    // Method to be called when the start button is clicked
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void HomeScreen()
    {
        SceneManager.LoadScene(homeSceneName);
    }
}