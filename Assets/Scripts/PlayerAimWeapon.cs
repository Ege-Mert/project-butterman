using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.Diagnostics;
using UnityEditor;
using System;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;
using Unity.VisualScripting;

public class PlayerAimWeapon : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs {
        public Vector3 gunEndPonitPosition;
        public Vector3 shootPosition;
    }

    private Transform aimTransform;
    private Transform aimGunEndPointTransform;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");
    }

    private void Update()
    {
        HandleAiming();
        HandleShooting();

    }

    private void HandleAiming(){
        // I aint written the whole code from the ground fuck that shit I am just gonna steal the already made package by CodeMonkey thank you
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimLocalScale = Vector3.one;
        if (angle > 90 || angle < -90){
            aimLocalScale.y = -1f;
        } else {
            aimLocalScale.y = +1f;
        }
        aimTransform.localScale = aimLocalScale;
        
    }

    private void HandleShooting(){
        if (Input.GetMouseButton(0)){
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            Debug.Log("Hello");

            OnShoot?.Invoke(this, new OnShootEventArgs{
                
                gunEndPonitPosition = aimGunEndPointTransform.position, shootPosition = mousePosition,
            });

        }
    }
}
