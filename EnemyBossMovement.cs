using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform; // Assign this in the Unity Editor
    public float speed = 1.0f; // The speed at which the enemy moves towards the player

    void Update()
    {
        if (playerTransform != null)
        {
            // Move the enemy object towards the player
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction to the player only on the x-axis
        Vector3 directionToPlayer = new Vector3(playerTransform.position.x - transform.position.x, 0, 0); // Focus on x-axis movement

        // Normalize the direction vector to ensure consistent movement speed
        directionToPlayer.Normalize();

        // Calculate the new position using only the x-axis for movement
        Vector3 newPosition = transform.position + directionToPlayer * speed * Time.deltaTime;
        
        // Update the enemy's position, only changing the x-axis.
        transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z); // Keep y and z constant
    }
}
