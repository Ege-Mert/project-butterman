using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 40;

    public Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null){
            enemy.TakeDamage(damage);
        }
        BoosAtack boss = hitInfo.GetComponent<BoosAtack>();
        if (boss != null){
            Debug.Log("Getting the info");
            boss.BossTakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
