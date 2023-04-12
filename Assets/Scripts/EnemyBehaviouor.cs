using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviouor : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player detected! Attack!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range! Resume patrol!");
            
        }
    }

    
}
