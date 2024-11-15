using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FireProjectile : MonoBehaviour
{
    public static FireProjectile instance; // Fire projectil instance
    private ItemCollector itemCollector; // Reference to item collector

    [SerializeField] private float bulletSpeed = 10.0f; // Bullet speed
    [SerializeField] private Bullet bulletPrefab; // Reference to bullet prefab
    [SerializeField] private Transform bulletSpawnPoint; // Reference to bullet spawning point
    [SerializeField] public float fireRate = 240.0f; // Rounds per minute

    private float nextFireTime = 0f; // Time of the next allowed fire
    private SpriteRenderer sr; // Reference to sprite renderer
    private static int enemyKillCount = 0; // Track the number of enemies killed
    public float originalFireRate; // Original fire rate
    [SerializeField] private AudioSource shootSound; // Reference to audi source
    [SerializeField] public Text displayText; // Reference to power up display text 
    private PlayerLife playerLife; // Reference to player's life script 
    private void Awake()
    {
        // Initialize the singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Ensures there's only one instance
        }
        playerLife = GetComponent<PlayerLife>(); // Get the PlayerLife component
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalFireRate = fireRate; // Store the original fire rate
    }

    private void Update()
    {
        // Check if the player is alive before allowing them to fire
        if (Input.GetKeyDown(KeyCode.X) && Time.time >= nextFireTime && playerLife.IsAlive())
        {
            Fire();
            nextFireTime = Time.time + 60f / fireRate;
        }
    }

    private void Fire()
    {
        SpawnBullet();
    }

    public void SpawnBullet()
    {
        // Instantiate a bullet and set its velocitu based on palyer's direction
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        shootSound.Play(); // Play the sound

        // Depends on the Player object
        rb.velocity = sr.flipX ? Vector2.left * bulletSpeed : Vector2.right * bulletSpeed;
    }

    // Call this method when an enemy is killed
    public static void EnemyKilled()
    {
        enemyKillCount++;
        Debug.Log("Enemy killed: " + enemyKillCount);
        if (enemyKillCount >= 10)
        {
            enemyKillCount = 0;
            instance.displayText.text = "FASTER SHOOTING"; // Access via instance
            instance.StartCoroutine(instance.BoostFireRate()); // Start coroutine for power up
        }
    }

    private IEnumerator BoostFireRate()
    {
        fireRate *= 2; // Double the fire rate
    
        yield return new WaitForSeconds(5); // Wait for 10 seconds
        fireRate = originalFireRate; // Reset the fire rate
        displayText.text = "";

         ResetKillCount(); // Reset the kill count after the boost effect ends
    }

    public static void ResetKillCount()
    {
        enemyKillCount = 0; // Properly reset the kill count
    }
}
