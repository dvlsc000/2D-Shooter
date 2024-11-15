using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void StartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // Check if the current scene is the last one
        if (currentSceneIndex == totalScenes - 1)
        {
            // If so, go back to scene 0
            SceneManager.LoadScene(0);
        }
        else
        {
            // Otherwise, load the next scene
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
