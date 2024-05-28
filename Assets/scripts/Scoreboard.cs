using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour

{

    public static int points = 0;
    static int pointsGoal = 10; 
   
    void OnGUI()
    {
        GUILayout.Box("Points: " + points);
    }

    // Update is called once per frame
    void Update()
    {
        if (points >= pointsGoal)
        {
            points = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinningScene");
        }
    }
}
