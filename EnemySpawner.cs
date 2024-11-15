using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab; // Reference to enemy prefab
    [SerializeField] private Transform enemyParent; // Reference to parent transform for organizing spawned enemies
    [SerializeField] private float spawnDelay = 2f; // Delay before spawning first enemy 
    [SerializeField] private float spawnInterval = 3f; // Time interval between spawns
    public Transform player; // Public or serialized reference to the player

    private SpawnPoints[] spawnPoints; // Array of spawn points

    void Start()
    {
        // Initialize components
        spawnPoints = GetComponentsInChildren<SpawnPoints>();
        // Start spawning enemies with delay and interval
        InvokeRepeating("SpawnOneEnemy", spawnDelay, spawnInterval);
    }

    private void SpawnOneEnemy()
    {
        if (spawnPoints.Length > 0)
        {
            // Chose a random spawn point index
            int i = Random.Range(0, spawnPoints.Length);

            // Instantiate the enemy at the selected spawn point
            Enemy e = Instantiate(enemyPrefab, spawnPoints[i].transform.position, Quaternion.identity, enemyParent);

            // Get the object movement component of the spawned enemy 
            ObjectMovement movement = e.GetComponent<ObjectMovement>();

            // If object movement component exists set player as target
            if (movement != null)
            {
                movement.SetTarget(player);
            }
            else
            {
                Debug.LogError("ObjectMovement component not found on the spawned enemy.");
            }
        }
    }

}