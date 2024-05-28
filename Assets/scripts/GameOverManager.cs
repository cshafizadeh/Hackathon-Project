using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public string gameOverSceneName = "GameOver"; // Replace with the name of your game over scene

    public void EndGame()
    {
        // Load the game over scene
        SceneManager.LoadScene(gameOverSceneName);
    }
}

