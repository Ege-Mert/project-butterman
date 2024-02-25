using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class BoosAtack : MonoBehaviour
{
   private float timeBtwShoot;
   public float startBtwShoot;
   public GameObject bossBullet;
   public GameObject bulletExit;
   public float BossHealth=5000f;//Bunu değiştirirsin.
   public bool changeGravity;
   private float WaitForChangeGravity;
   public bool ackapa;
   private bool kapaac;
   public bool FazeTwoGravity;


   public BossHealthSlider bossHealthBar;

   [SerializeField] private Animator _animator;
   
   
   
   

   private void Start()
   {
      timeBtwShoot = startBtwShoot;
      changeGravity = false;
      ackapa = true;
      kapaac = true;
      bossHealthBar.SetMaxBossHealth(BossHealth);
   }

   private void Update()
   {
      int i = Random.Range(1, 3);
      
      
      if (BossHealth>2500&& BossHealth<=5000&& ackapa)
      {
         StartCoroutine(GravityScaler());

      }

      if (BossHealth<= 2500 && kapaac)
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
      if (IsDead()){
         BossDie();
      }
      
   }

   private bool IsDead()
   {
      Debug.Log("Boss Ded");
      return BossHealth <= 0;
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
      WaitForChangeGravity= Random.Range(2f, 4f);
      yield return new WaitForSeconds(WaitForChangeGravity);
      FazeTwoGravity = false;
      yield return new WaitForSeconds(WaitForChangeGravity);
      kapaac = true;
   }

   public void BossTakeDamage(int damage){
      Debug.Log("Boss taking damage");
      BossHealth -= damage;
      bossHealthBar.SetBossHealth((int)BossHealth);
   }


   private void BossDie(){
      SceneManager.LoadScene("EndingScene");
      
   }

}

