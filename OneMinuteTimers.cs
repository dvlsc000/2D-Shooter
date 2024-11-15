using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public Text timerText; // Assign your UI Text component in the inspector
    private float timerDuration = 60f; // Duration of the timer in seconds
    private float timeRemaining; // Time remaining on the timer

    void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("Timer Text UI component not assigned!");
            return;
        }

        timeRemaining = timerDuration;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            // Decrease the time remaining
            timeRemaining -= Time.deltaTime;

            // Update the timer text
            timerText.text = "Timer: " + Mathf.Ceil(timeRemaining).ToString();

            if (timeRemaining <= 0)
            {
                // Time's up, destroy objects with tag "Doors2"
                GameObject[] doorsToDestroy = GameObject.FindGameObjectsWithTag("Doors2");
                foreach (GameObject door in doorsToDestroy)
                {
                    Destroy(door);
                }
            }
        }
    }
}
