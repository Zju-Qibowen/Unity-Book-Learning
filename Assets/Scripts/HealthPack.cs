using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HealthPack : MonoBehaviour
{
    public int healAmount = 1;
    public bool hitPlayer = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        hitPlayer = true;
        if (other.CompareTag("Ruby"))
        {
            Debug.Log("Ruby hit the healthpack!");
            RubyController player = other.GetComponent<RubyController>();
            HealthPack healthPack = GetComponent<HealthPack>();
            if (player != null && player.HP < player.maxHealth)
            {
                player.AddHealth(healAmount);
                Destroy(this.gameObject);
            }
            else if (player == null)
            {
                Debug.LogError("未获取到Player！");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        hitPlayer = false;
    }
}
