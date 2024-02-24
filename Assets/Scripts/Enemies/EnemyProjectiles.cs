using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    public float enemyPrjSpeed;
    public int damage;
    public float lifespan = 6.0f;
    public LayerMask obstacleLayer;

    private Transform player;
    private Vector2 direction;
    private float elapsedTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = player.position - transform.position;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y) +
                            direction.normalized * enemyPrjSpeed * Time.deltaTime;

        elapsedTime += Time.deltaTime;


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
            Perish();
        }
    }

    void Perish()
    {
        Destroy(gameObject);
    }
}
