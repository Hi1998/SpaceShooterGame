using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCollisionDetector : MonoBehaviour
{
    /// <summary>
    /// Enemy hit animation when bullet hit the enemies
    /// </summary>
    [SerializeField]
    private GameObject collisionParticleprefab;

    /// <summary>
    /// Reference to ScoreManager
    /// </summary>
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreControl").GetComponent<ScoreManager>();
    }

    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            // Get the contact point of the collision
            Vector2 collisionPoint = collision.contacts[0].point;

            // Instantiate the particle system at the collision point
            GameObject particleSystemInstance = Instantiate(collisionParticleprefab, collisionPoint, Quaternion.identity);
            // Ensure the particle system plays immediately
            ParticleSystem particleSystem = particleSystemInstance.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play(); // Explicitly start the particle system
            }
            // Increment Score
            if(collision.gameObject.tag == "Enemy")
            {
                scoreManager.IncrementScore();
            }
            Destroy(particleSystemInstance, particleSystem.main.duration);
            Destroy(collision.gameObject);
        }
    }
}
