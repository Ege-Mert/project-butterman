using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthMax = 100;
    public int playerHealth;

    public PlayerHealthBar healthBar;
    public GameManagerScript gameManager;

    private bool isDead;
    private bool isInvincible;
    private float invincibilityDuration = 2.0f;
    private float invincibilityRecharge = 4.0f;
    private float invincibilityTimer = 0.0f;
    private float invincibilityRechargeTimer = 0.0f;

    void Start()
    {
        playerHealth = healthMax;
        healthBar.SetMaxHealth(healthMax);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            playerHealth -= damage;
            healthBar.SetHealth(playerHealth);

            if (playerHealth <= 0 && !isDead)
            {
                Debug.Log("PlayerDed");
                gameManager.gameOver();
                isDead = true;
                Debug.Log("PlayerDed2");
            }
            else
            {
                StartInvincibility();
            }
        }
    }

    private void StartInvincibility()
    {
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0.0f)
            {
                isInvincible = false;
                invincibilityRechargeTimer = invincibilityRecharge;
            }
        }
        else if (invincibilityRechargeTimer > 0.0f)
        {
            invincibilityRechargeTimer -= Time.deltaTime;
        }
    }
}
