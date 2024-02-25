using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public BoosAtack _boosAtack;
    private bool fonkCagir;
    private bool fonkCagir2;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boosAtack = FindObjectOfType<BoosAtack>();
        fonkCagir = true;
        fonkCagir2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_boosAtack.changeGravity&& fonkCagir)
        {
            StartCoroutine(GravityExchange());
            
            
        }
        
        if (_boosAtack.FazeTwoGravity&& fonkCagir2)
        {
            StartCoroutine(ExchangeFazeTwoGravity());
            Debug.Log("sex");
            
        }
        
        
    }

    IEnumerator GravityExchange()
    {
        fonkCagir = false;
        _rigidbody2D.gravityScale *= -1;
        yield return new WaitForSecondsRealtime(7f);
        fonkCagir = true;
    }

    IEnumerator ExchangeFazeTwoGravity()
    {
        fonkCagir2 = false;
        float gravity= Random.Range(-50f, 50f);
        _rigidbody2D.gravityScale = gravity;
        yield return new WaitForSecondsRealtime(5f);
        _rigidbody2D.gravityScale = 1f;
        fonkCagir2 = true;
    }
}
