using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public  float smooting;
    public Vector2 maxPos;
    public Vector2 MinPos;
    

    private void Update()
    {
        if (transform.position != target.position)
        {
            Vector3 targetpos = new Vector3(target.position.x, target.position.y,transform.position.z);
            targetpos.x = Mathf.Clamp(targetpos.x, MinPos.x, maxPos.x);
            targetpos.y = Mathf.Clamp(targetpos.y, MinPos.y, maxPos.y);
            transform.position = Vector3.Lerp(transform.position, targetpos, smooting);


        }
        
    }
}
