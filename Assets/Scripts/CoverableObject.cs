using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverableObject : MonoBehaviour
{
    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerState playerState = other.GetComponent<PlayerState>();
            if (playerState.IsBowEquipped)
            {
                playerState.IsStealthed = true; 
            }
            else
            {
                playerState.IsStealthed = false; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerState playerState = other.GetComponent<PlayerState>();
            playerState.IsStealthed = false;
        }
    }
}
