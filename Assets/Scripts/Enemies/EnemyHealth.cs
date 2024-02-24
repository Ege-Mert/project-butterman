using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 100;

    public bool IsDead()
    {
        return enemyHealth <= 0;
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (IsDead())
        {
            Debug.Log("IsDed");
        }
    }

    public void Die()
    {
        Debug.Log("Ded");
        Destroy(gameObject);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
