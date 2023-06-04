using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    //每次扣血的数量
    public int damage;
    private RubyController player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ruby"))
        {
            RubyController player = other.GetComponent<RubyController>();
            Debug.Log("Ruby hit the spike!");
            if (player != null && player.HP >0 )
            {
                player.MinusHealth(damage);
            }
            
            else if (player == null)
            {
                Debug.LogError("未获取到Player！");
            }
           
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ruby"))
        {
            RubyController player = other.GetComponent<RubyController>();
            Debug.Log("Ruby hit the spike!");
            if (player != null && player.HP >0 )
            {
                player.MinusHealth(damage);
            }
            
            else if (player == null)
            {
                Debug.LogError("未获取到Player！");
            }
           
        }
    }
    
    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     RubyController player = other.GetComponent<RubyController>();
    //     StartCoroutine(player.InvincibilityCoroutine());
    //     if (player != null && player.HP >0 && !player.isInvincible)
    //     {
    //         player.MinusHealth(damage);
    //     }
    //     else if (player.isInvincible)
    //     {
    //         Debug.Log("Player is invincible!");
    //     }
    //     else if (player == null)
    //     {
    //         Debug.LogError("未获取到Player！");
    //     }
    // }
}
