using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// / The 2D Enemy Spawan to instantiate
    /// </summary>
    public GameObject EnemySpawn;

    public Transform SpawnPosition1;
    /// <summary>
    /// speed of enemy
    /// </summary>
    public float EnemySpeed;

    /// <summary>
    /// Timing interval for enemies get spawned one by one
    /// </summary>
    public float spawnInterval;

    /// <summary>
    /// Timing when was Enemy Spawned.
    /// </summary>
    private float timeSinceLastSpawn; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the time since last spawn
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            // Reset the timing after Spawning
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnEnemy()
    {
        // Instantiate the prefab at the calculated position
        GameObject spawnedPrefab = Instantiate(EnemySpawn, SpawnPosition1.position, EnemySpawn.transform.rotation);

        // Move the object downward in the random direction
        spawnedPrefab.GetComponent<Rigidbody>().velocity = new Vector3(0, -EnemySpeed, 0);
    }

    // IEnumerator EnemiesSpawned()
    // {
    //     yield return new WaitForSeconds(4f);

    //     // Instantiate the prefab at the calculated position
    //     GameObject spawnedPrefab = Instantiate(EnemySpawn, SpawnPosition1.position, EnemySpawn.transform.rotation);
    //     // Move the object downward in the random direction
    //     spawnedPrefab.GetComponent<Rigidbody>().velocity = new Vector3(0, -EnemySpeed, 0);

    // }
}
