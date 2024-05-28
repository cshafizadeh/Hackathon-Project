using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    public string endScreenSceneName = "EndScreen"; // Replace with the name of your end screen scene

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(endScreenSceneName);
        }
    }
}
