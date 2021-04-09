using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
   public EnemyState[] AllEnemies;
   public int TotalEnemies;
   public int CurrentEnemyCount;
   

   private void Start()
   {
      AllEnemies = GetComponentsInChildren<EnemyState>();
      TotalEnemies = AllEnemies.Length;
      CurrentEnemyCount = TotalEnemies;
      AddListenerToEnemies();
   }

   void AddListenerToEnemies()
   {
      foreach (var enemy in AllEnemies)
      {
         enemy.GetComponent<EnemyController>().EnemyDeath.AddListener(EnemyDeath);
      }   
   }

   public void EnemyDeath()
   {
      CurrentEnemyCount--;
      if (CurrentEnemyCount <= 0)
      {
         GameManager.instance.GameWon();
      }
   }
}
