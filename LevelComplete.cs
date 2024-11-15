using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
  
    private AudioSource finishSound;  // Reference to audio source
    private void Start()
    {
        // Attatch audio source to game object
        finishSound = GetComponent<AudioSource>();
    }
    // When 2D collider enters a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if colliding objecct is tagged as "Player"
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("TOUCHING ! ! !");
            // Play the sound
            finishSound.Play();
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 2)
            {
                PlayerPrefs.SetString("ResultText", "YOU WON !");
            }
            // Load the next scene in bulid settings
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
