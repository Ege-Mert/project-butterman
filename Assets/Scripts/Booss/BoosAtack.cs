using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoosAtack : MonoBehaviour
{
   private float timeBtwShoot;
   public float startBtwShoot;
   public GameObject bossBullet;
   public GameObject bulletExit;
   public float BossHealth=75f;//Bunu değiştirirsin.
   public bool changeGravity;
   private float WaitForChangeGravity;
   public bool ackapa;
   private bool kapaac;
   public bool FazeTwoGravity;
   [SerializeField] private Animator _animator;
   
   
   
   

   private void Start()
   {
      timeBtwShoot = startBtwShoot;
      changeGravity = false;
      ackapa = true;
      kapaac = true;
      _animator.SetBool("fazeTwo",false);
   }

   private void Update()
   {
      int i = Random.Range(1, 3);
      
      
      if (BossHealth>25&& BossHealth<=50&& ackapa)
      {
         StartCoroutine(GravityScaler());

      }

      if (BossHealth<= 25 && kapaac)
      {
         FazeTwo();
         Debug.Log("FazeTwoFonkÇağırıldı");
      }

      
      if (timeBtwShoot <=0 )
      {
         if (i==2)
         {
            StartCoroutine(ThereBullet());
         }
         else
         {
            Instantiate(bossBullet, bulletExit.transform.position, Quaternion.identity); 
            timeBtwShoot = startBtwShoot;
         }
         
      }
      else
      {
         timeBtwShoot -= Time.deltaTime;
      }
      
   }
   

   private IEnumerator GravityScaler()
   {
      ackapa = false;
      changeGravity = true;
      WaitForChangeGravity= Random.Range(5f, 10f);
      yield return new WaitForSeconds(WaitForChangeGravity);
      changeGravity = false;
      yield return new WaitForSeconds(WaitForChangeGravity);
      ackapa = true;
   }

   IEnumerator ThereBullet()
   {
      Instantiate(bossBullet, bulletExit.transform.position, Quaternion.identity);
      yield return new WaitForSeconds(0.2f);
      Instantiate(bossBullet, bulletExit.transform.position, Quaternion.identity);
      yield return new WaitForSeconds(0.2f);
      Instantiate(bossBullet, bulletExit.transform.position, Quaternion.identity);
      yield return new WaitForSeconds(0.2f);
   }
   //*************************************************************************************************************************************

   void FazeTwo()
   {
      Debug.Log("FazeTwoOnline");
      StartCoroutine(FazeTwoGravityy());
      _animator.SetBool("fazeTwo",true);
      
   }

   IEnumerator FazeTwoGravityy()
   {
      Debug.Log("Ienumeratorde çalışıyore");
      kapaac = false;
      FazeTwoGravity = true;
      WaitForChangeGravity= Random.Range(5f, 10f);
      yield return new WaitForSeconds(WaitForChangeGravity);
      FazeTwoGravity = false;
      yield return new WaitForSeconds(WaitForChangeGravity);
      kapaac = true;
   }

}

