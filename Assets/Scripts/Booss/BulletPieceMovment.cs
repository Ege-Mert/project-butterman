using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPieceMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.position,ForceMode2D.Force);
    }
}
