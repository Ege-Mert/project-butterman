using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvolution : MonoBehaviour
{
    public int killThreshold = 3; // Number of enemies to kill per evolution
    public int maxEvolutions = 3; // Maximum number of evolution stages
    public List<Sprite> evolutionSprites; // List of sprites for each evolution stage

    private int currentEvolution = 0;
    private int kills = 0;
    private SpriteRenderer spriteRenderer;
    
    // Define the trigger radius variable
    public float triggerRadius = 1.0f; // Adjust this value as needed

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("PlayerEvolution script started. Trigger radius: " + triggerRadius);
    }

    void Update()
    {
        // Check for enemy death within trigger radius
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, triggerRadius);
        Debug.Log("Checking for enemies within trigger radius.");

        foreach (Collider2D enemyCollider in enemiesHit)
        {
            EnemyHealth enemyHealth = enemyCollider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Debug.Log("Found enemy: " + enemyCollider.gameObject.name);
                if (enemyHealth.IsDead()) // Ensure EnemyHealth has IsDead method
                {
                    Debug.Log("FoundEnemyIsDed");
                    kills++;
                    CheckForEvolution();
                    enemyHealth.GetComponent<EnemyHealth>()?.Die();
                }
            }
        }
    }

    void CheckForEvolution()
    {
        Debug.Log("Cehecking for EVO");
        if (kills >= killThreshold && currentEvolution < maxEvolutions)
        {
            Debug.Log("Evolution criteria met! Kills: " + kills + ", Current evolution: " + currentEvolution);
            kills -= killThreshold; // Reset kill count for next evolution
            currentEvolution++;
            spriteRenderer.sprite = evolutionSprites[currentEvolution];

            // Update other relevant player attributes (optional)
            // e.g., increase movement speed, firing rate, damage, etc.
            // UpdatePlayerStats(currentEvolution);
        }
    }

    // Optional function to update player stats based on evolution level
    void UpdatePlayerStats(int evolutionLevel)
    {
        // Implement logic to modify player stats based on evolution level
        switch (evolutionLevel)
        {
            case 1:
                // Increase movement speed by 10%
                break;
            case 2:
                // Increase firing rate by 20%
                break;
            case 3:
                // Increase bullet damage by 30%
                break;
            default:
                break;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
