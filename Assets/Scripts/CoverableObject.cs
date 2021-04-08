using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverableObject : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in Object");
        }
    }
}
