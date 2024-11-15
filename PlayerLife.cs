using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb; // Reference to RigidBody component
    private Animator anim; // Reference to animtor compinent
    [SerializeField] private AudioSource deathSound; // Reference to audio source
    [SerializeField] private Image[] hearts; // Array of heart images
    private static int life = 3; // Static to persist across scene loads
    private bool isDead = false; // Flag to check if player is already dead
    private ItemCollector itemCollector; // Reference to the ItemCollector
    private FireProjectile fireProjectile; // Reference to player attacking script

    void Start()
    {
        // Initilaize components
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        itemCollector = FindObjectOfType<ItemCollector>(); // Get the ItemCollector component
        UpdateHeartImages(); // Update heart images at start
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collides with an enemy and is not already dead 
        if (collision.gameObject.CompareTag("Enemy") && !isDead)
        {
            Die(); // Call die method
            Debug.Log("TOUCHING!");
        }
    }

    private void Die()
    {
        itemCollector.ResetCoins(); // Reset the coin count when restarting level
        // Check if the player is not dead already
        if (!isDead)
        {
            isDead = true; // Set isDead to true to prevent multiple deaths
            deathSound.Play(); // Play the sound 
            rb.bodyType = RigidbodyType2D.Static; // Set rigid body to static
            anim.SetTrigger("death"); // trigger the death animation 
            Invoke("RestartLevel", 2f); // Delay to allow death animation and sound
        }
    }

    public void AddLife()
    {
        if (life < 3) // Ensure life does not exceed 3
        {
            life++; // Increment the life count
            UpdateHeartImages(); // Update the heart images
        }
    }

    public bool IsAlive()
    {
        return !isDead;
    }

   private void RestartLevel()
{
    life--; // Decrement life first
    if (life > 0)
    {
        // If player still has lives left, restart the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isDead = false;
        UpdateHeartImages(); // Update heart images
    }
    else 
    {
        // If all lives are lost, reset life count, update the heart images for the new game, and go to scene index 4
        life = 3;
        isDead = false;
        PlayerPrefs.SetString("ResultText", "YOU LOST");
        SceneManager.LoadScene(4);
    }
}

    private void UpdateHeartImages()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Show heart if index is less than current life, otherwise hide it
            hearts[i].gameObject.SetActive(i < life);
        }
    }
}
