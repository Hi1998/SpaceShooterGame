using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipController : MonoBehaviour
{
    new Rigidbody rigidbody;

    /// <summary>
    /// Speed of the Space ship
    /// </summary>
    [SerializeField]
    float speed;

    /// <summary>
    /// Bullet Game Object which we need to instantiate whenevr we click
    /// </summary>
    [SerializeField]
    GameObject Bullet;

    /// <summary>
    /// At what position where bullets can spawn.
    /// </summary>
    [SerializeField]
    Transform bulletPos;

    /// <summary>
    /// Speed of Bullet
    /// </summary>
    public float bulletSpeed;

    /// <summary>
    /// Movement of the Spaceship in X axis and Y axis
    /// </summary>
    float inputX, inputY;

    public Health SpaceshipHealth;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        SpaceshipHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        // Velocity we are using to use the physics of the game object to move the Game Object
        rigidbody.velocity = new Vector3(inputX * speed, inputY * speed, rigidbody.velocity.z);

        // When we press the button we fire the bullet
        if(Input.GetButtonDown("Jump") && Time.timeScale > 0)
        {
            Shoot();
        }

        /* Not Removing the below code as the below code is also for the movement of the GameObject */
        // // Movement of the Spaceship in the right direction.
        // if(Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     transform.position += new Vector3(1f, 0, 0);
        // }
        // // Movement of the Spaceship in the left direction.
        // else if(Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     transform.position += new Vector3(-1f, 0, 0);
        // }
        // // Movement of the Spaceship in the Up direction.
        // else if(Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     transform.position += new Vector3(0, 1f, 0);
        // }
        // // Movement of the direction in the down direction.
        // else if(Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     transform.position += new Vector3(0, -1f, 0);
        // }
    }

    void Shoot()
    {
        GameObject spawnBullets = Instantiate(Bullet, bulletPos.position, Bullet.transform.rotation);
        spawnBullets.GetComponent<Rigidbody>().velocity = new Vector3(0, bulletSpeed, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "EnemyBullet")
        {
            SpaceshipHealth.DamageSpaceShip(10);
            Destroy(other.gameObject);
            if(SpaceshipHealth.currentHealth <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("LoadingScene");
            }
        }
        if(other.gameObject.tag == "Enemy")
        {
            // Whenever the Enemy collide with the spaceship then we start the loading scene.
            SceneManager.LoadScene("LoadingScene");
        }
    }
}
