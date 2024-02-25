using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private float speed = 20f;
    private Vector2 direction;
    
    public Transform player;
    private Vector2 target;
    public GameObject BulletPiece;
    public LayerMask layerMask;

    public float raycastDistance = 20f;

        public int bossBulletDamage;




    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        direction = (player.position - transform.position).normalized;
    }
  private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(bossBulletDamage);
            }
            DestroyAndParcalan();
        }
        else
        {
            DestroyAndParcalan();
            Debug.Log("syok");
        }
    }
    private void Update()
    {
        // Move the bullet in the direction it was instantiated
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the bullet is very close to the player's position
        if (Vector2.Distance(transform.position, player.position) < 0.1f)
        {
            // Deal damage to the player and destroy the bullet
            DestroyAndParcalan();
        }
    }

    
    void DestroyAndParcalan()
    {
        
        Destroy(gameObject);
       
        
    }

   


}
