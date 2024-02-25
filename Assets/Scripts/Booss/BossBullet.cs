using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private float spedd = 10f;
    public Transform player;
    private Vector2 target;
    public GameObject BulletPiece;
    public LayerMask layerMask;
    public float raycastDistance = 20f;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
  private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //player canını burada azaltıyorsun 
            Debug.Log("sex");
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
        transform.position = Vector2.MoveTowards(transform.position, target, spedd * Time.deltaTime);
        if (transform.position.x==target.x && transform.position.y == target.y)
        {
           DestroyAndParcalan();
        }
    }

  

  

    void DestroyAndParcalan()
    {
        
        Destroy(gameObject);
       
        
    }

   


}
