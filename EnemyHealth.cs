using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Initialize maximum enemy health
    private int currentHealth;

    private EnemyMovement enemyMovement; // Reference to enemy's movement script

    [SerializeField] private Vector3 healthSliderPositionOffset = new Vector3(0, 1.5f, 0); // Initialize health bar right above the object

    [SerializeField] private Slider healthSlider; // Reference to the health slider UI element

    [SerializeField] private GameObject dropItemPrefab; // Reference to item object that is dropped after enemy is killed
    private bool hasDroppedItem = false; // Track if the item has been dropped
    private bool isDead = false; // Track if the enemy is already dead

    void Start()
    {
        // Current health assigned to maxHealth variable
        currentHealth = maxHealth;
        // Initialize component
        enemyMovement = GetComponent<EnemyMovement>();

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth; // Assign max value to health slider
            healthSlider.value = currentHealth; // Assign current value to health slider
            healthSlider.transform.position = transform.position + healthSliderPositionOffset; // Position health slider
        }
    }

    
    public void TakeDamage(int damage)
    {
        if (isDead) return; // Exit if the enemy is already dead

        currentHealth -= damage; // Reduce enemy's health

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth; // Update health slider
        }

        if (enemyMovement != null)
        {
            enemyMovement.speed += 1.0f; // Increase enemy movement speed
        }

        // If current health is less or equal to 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return; // Ensure Die is only processed once

        isDead = true; // Mark as dead to prevent duplicate calls

        Debug.Log("Die called for " + gameObject.name);

        FireProjectile.EnemyKilled(); // Notify that an enemy has been killed

        if (dropItemPrefab != null && !hasDroppedItem)
        {
            Debug.Log("Instantiating drop item for " + gameObject.name);
            Instantiate(dropItemPrefab, transform.position, Quaternion.identity); // Instantiate coin object after enemy dies
            hasDroppedItem = true; // Ensure no more items are dropped after the first
        }

        Destroy(gameObject); // Destroy the enemy object
    }
}
