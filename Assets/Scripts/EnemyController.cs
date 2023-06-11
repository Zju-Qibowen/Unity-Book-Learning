using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;    // 移动速度
    public float moveDistance; // 移动距离
    private float startX;           // 初始位置的x坐标
    private float targetX;          // 目标位置的x坐标
    public bool movingRight = true; // 是否向右移动
    public int hitDamage = 1;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool isbroken = true;
    private BoxCollider2D _boxCollider2D;
    public ParticleSystem smokeEffect;

   

    void Start()
    {
        startX = transform.position.x;
        targetX = startX + moveDistance;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    //敌人碰撞扣血
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ruby"))
        {
            RubyController player = other.gameObject.GetComponent<RubyController>();
            if (player != null && player.HP >0)
            {
                player.MinusHealth(hitDamage);
            }
            else
            {
                Debug.Log("player null(Enemy Hit Method)");
            }
        }
    }
    //机器人被修复方法
    public void Fix()
    {
        isbroken = false;
        //取消刚体的物理模拟
        _rigidbody2D.simulated = false;
        _animator.SetBool("isFixed",true);
        //停止产生新的粒子
        smokeEffect.Stop();

    }
    
    void Update()
    {
        //如果被修好了，就跳出此方法
        // 根据移动方向计算目标位置
            float targetPositionX = movingRight ? targetX : startX;

            // 计算移动方向和速度
            float moveDirection = movingRight ? 1f : -1f;


            // 设置刚体的速度
            if (isbroken)
            {
                //如果还未修复，就继续移动
                _rigidbody2D.velocity = new Vector2(moveDirection * moveSpeed, 0);
            }
            else
            {
                //如果修复了，速度为零
                _rigidbody2D.velocity = Vector2.zero;
            }

            // 到达目标位置后改变移动方向
            if (Mathf.Approximately(transform.position.x, targetPositionX))
            {
                movingRight = !movingRight;
            }

            if (movingRight)
            {
                _animator.SetFloat("MoveX", 0.5f);
                _animator.SetFloat("MoveY", 0f);
            }

            if (!movingRight)
            {
                _animator.SetFloat("MoveX", -0.5f);
                _animator.SetFloat("MoveY", 0f);

            }

    }
}
