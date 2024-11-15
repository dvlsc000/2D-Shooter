using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // To reference player's transform
    [SerializeField] private Transform player;

    void Update()
    {
        // Set the camera's position to follow the player's X and Y position, keeping the same Z position
        transform.position = new Vector3(player.position.x, player.position.y + 2, transform.position.z);
    }
}
