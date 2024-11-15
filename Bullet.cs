using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f; // Bullet lifetime
    public int damage = 20; // Damage done by bullet

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy the bullet after a certain time to clean up
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If bullet collides with object: Enemy, Monster, Boss
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Boss"))
        {
            // Reference to enemy health script for all of the objects above
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // Apply damage to the enemy
            }
            Destroy(gameObject); // Destroy the bullet after hitting
        }
        // Stop the bullet going through map and objects
           if (collision.gameObject.CompareTag("Map") || collision.gameObject.CompareTag("Doors"))
        {
            Destroy(gameObject); // Destroy the bullet after hitting an enemy
        }
    }
}
