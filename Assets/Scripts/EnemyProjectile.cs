using System.Collections;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float enemyPrjSpeed;
    public int damage;
    public float lifespan = 6.0f; // Time in seconds before self-destruction
    public LayerMask obstacleLayer; // Inspector-exposed layer for obstacles

    private Transform player;
    private Vector2 direction;
    private float elapsedTime; // Track elapsed time

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = player.position - transform.position; // Calculate direction
    }

    void Update()
    {
        // Ensure consistency with Vector2:
        transform.position = new Vector2(transform.position.x, transform.position.y) +
                            direction.normalized * enemyPrjSpeed * Time.deltaTime;

        // Update timer:
        elapsedTime += Time.deltaTime;

        // Destroy after lifespan:
        if (elapsedTime >= lifespan)
        {
            Perish();
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = trigger.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Perish();
        }
        else if (obstacleLayer == (obstacleLayer | (1 << trigger.gameObject.layer)))
        {
            // Collided with an object on the specified layer ("obstacle")
            Perish();
        }
    }

    void Perish()
    {
        Destroy(gameObject);
    }
}
