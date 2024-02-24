using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public BoosAtack _boosAtack;
    private bool fonkCagır;
    private bool fonkCagır2;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boosAtack = FindObjectOfType<BoosAtack>();
        fonkCagır = true;
        fonkCagır2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_boosAtack.changeGravity&& fonkCagır)
        {
            StartCoroutine(GravityExchange());
            
            
        }
        
        if (_boosAtack.FazeTwoGravity&& fonkCagır2)
        {
            StartCoroutine(ExchangeFazeTwoGravity());
            Debug.Log("sex");
            
        }
        
        
    }

    IEnumerator GravityExchange()
    {
        fonkCagır = false;
        _rigidbody2D.gravityScale *= -1;
        yield return new WaitForSecondsRealtime(7f);
        fonkCagır = true;
    }

    IEnumerator ExchangeFazeTwoGravity()
    {
        fonkCagır2 = false;
        float gravity= Random.Range(-5f, 5f);
        _rigidbody2D.gravityScale = gravity;
        yield return new WaitForSecondsRealtime(5f);
        _rigidbody2D.gravityScale = 1f;
        fonkCagır2 = true;
    }
}
