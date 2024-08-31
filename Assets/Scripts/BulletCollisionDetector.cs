using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionDetector : MonoBehaviour
{
    /// <summary>
    /// Enemy hit animation when bullet hit the enemies
    /// </summary>
    [SerializeField]
    private GameObject collisionParticleprefab;

    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
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
            Destroy(particleSystemInstance, particleSystem.main.duration);
            Destroy(collision.gameObject);
        }
    }
}
