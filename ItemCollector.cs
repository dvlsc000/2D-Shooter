using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0; // Counter for collected coins 
    [SerializeField] public Text displayText; // Displays the text of movement power up
    [SerializeField] public Text coinText; // Displays the number of collected coins
    [SerializeField] private AudioSource collectSound; // Reference to audio source 
    private Player_Movement playerMovement; // Reference to player's movement script


    private void Start()
    {
        // Initilize component
        playerMovement = GetComponent<Player_Movement>() ?? FindObjectOfType<Player_Movement>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with a coin
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins++; // Increment of the coin counter
            Debug.Log("Coin collected. Total now: " + coins);
            coinText.text = "" + coins; // Update the UI counter
            collectSound.Play(); // Play the sound 
            Destroy(collision.gameObject); // Destroy coin object

            // If player collect 4 coins
            if (coins % 4 == 0)
            {
                displayText.text = "FASTER MOVING"; // Display text
                StartCoroutine(DoubleSpeedTemporarily()); // Start coroutine to speed up
            }

            // If player collect 10 coins
            if (coins % 10 == 0)
            {
                // Find all game object tagged as "Doors" and destroy them
                GameObject[] doors = GameObject.FindGameObjectsWithTag("Doors");
                foreach (GameObject door in doors)
                {
                    Destroy(door);
                }
            }
            
            // If player collect 30 coins
            if (coins % 30 == 0)
            {
                coins = 0; // Reset coin count
                coinText.text = "" + coins; // Reset UI text counter

                // Find all game object tagged as "Doors" and destroy them
                GameObject[] doors = GameObject.FindGameObjectsWithTag("Doors2");
                foreach (GameObject door in doors)
                {
                    Destroy(door);
                }
            }

        }

        // Check if the collision is with a monster
         if (collision.gameObject.CompareTag("Monster"))
        {
            StartCoroutine(SlowSpeedTemporarily()); // Start coroutine for power down
            Destroy(collision.gameObject); // Destroy the object
        }
    }

    private IEnumerator DoubleSpeedTemporarily()
    {
        float originalSpeed = playerMovement.moveSpeed; // Store the original speed
        playerMovement.moveSpeed *= 1.5f; // Double the speed
        yield return new WaitForSeconds(5); // Wait for 10 seconds
        playerMovement.moveSpeed = originalSpeed; // Reset the speed to its original value
        displayText.text = "";
    }

     private IEnumerator SlowSpeedTemporarily()
    {
        float originalSpeed = playerMovement.moveSpeed; // Store the original speed
        playerMovement.moveSpeed *= 0.5f; // Double the speed
        yield return new WaitForSeconds(3); // Wait for 1 second
        playerMovement.moveSpeed = originalSpeed; // Reset the speed to its original value
    }
    // Public method to reset the count of coins
    public void ResetCoins()
    {
        coins = 0; // Set to 0
        coinText.text = coins.ToString(); // Set the display text
    }



}
