using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorLookAt : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float speed = 2f;  // Speed at which the enemy moves towards the player

    void Update()
    {
        // Calculate the direction from the enemy to the player
        Vector3 direction = player.position - transform.position;
        direction.Normalize(); // Normalize the direction to get a unit vector

        // Calculate the angle between the enemy and the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the calculated rotation to the enemy to face the player
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Move the enemy towards the player
        transform.position += direction * speed * Time.deltaTime;
    }
}
