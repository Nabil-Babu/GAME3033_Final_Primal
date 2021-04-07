using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
   public GameObject Player;
   public GameObject LookFrom;
   
   public float MinDetectionDistance = 10.0f;
   public float MinAngleofDetection = 90.0f;

   public bool playerIsInFront = false; 
   public bool playerIsInRange = false;

   private EnemyState _enemyState;
   private Vector3 _directionToTarget;
   private float _angleToPlayer;

   void Start()
   {
      _enemyState = GetComponent<EnemyState>();
      Player = FindObjectOfType<PlayerCamera>().followTarget;
   }

   private void Update()
   {
      playerIsInFront = inFront();
      playerIsInRange = inRange();
      if (inFront() && CheckLineOfSight() && inRange())
      {
         _enemyState.isTargetInLOS = true;
         Debug.DrawRay(LookFrom.transform.position, _directionToTarget, Color.green);
      }
      else
      {
         _enemyState.isTargetInLOS = false; 
      }
   }

   bool inFront()
   {
      Vector3 directionFromPlayer = LookFrom.transform.position - Player.transform.position;
      _angleToPlayer = Vector3.Angle(LookFrom.transform.forward, directionFromPlayer);
      if (_angleToPlayer > MinAngleofDetection)
      {
         return true;
      }
      return false;
   }

   bool inRange()
   {
      float distance = Vector3.Distance(LookFrom.transform.position, Player.transform.position);
      if (distance <= MinDetectionDistance)
      {
         return true;
      }
      return false; 
   }

   bool CheckLineOfSight()
   {
      RaycastHit hit;
      _directionToTarget = Player.transform.position - LookFrom.transform.position;
      if (Physics.Raycast(LookFrom.transform.position, _directionToTarget, out hit, Mathf.Infinity))
      {
         if (hit.transform.CompareTag("Player"))
         {
            return true;
         }
      }
      return false;
   }
   
}
