using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// 子弹发射相关字段
    /// </summary>
    public GameObject bullet;
    public float bulletSpeed = 150f;
    /// <summary>
    /// 移动和跳跃相关字段
    /// </summary>
    public float moveSpeed = 5f;
    public float rotateSpeed = 20f;
    public float jumpVelocity = 5f;
    /// <summary>
    /// 碰撞检测Layer字段
    /// </summary>
    private LayerMask groundLayer;
    /// <summary>
    /// 其他字段
    /// </summary>
    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;
    private float hInput;
    private float vInput;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        // 1 << 6，表示二进制的1000000，十进制为64。
        groundLayer = 1 << LayerMask.NameToLayer("Ground");
      
    }
    /// <summary>
    /// Jump是一种瞬时事件，而不是持续事件。因此，将Jump方法放在Update中比FixedUpdate更合适。
    /// Update方法每帧调用一次，适合处理一些瞬时事件，例如检测玩家的输入，响应按键等。
    /// 而FixedUpdate方法是固定时间间隔调用的，适合处理物理相关的事件，例如移动物体、施加力等。
    /// 在Jump方法中，我们要给玩家的刚体添加一个瞬时的力，使其跳跃起来，这并不涉及到物理引擎，因此使用Update更为合适。
    /// 如果我们把Jump方法放在FixedUpdate中，会导致在玩家按下空格键后需要等待下一次固定时间间隔才能执行Jump方法，
    /// 这样会导致玩家跳跃的体验感受不好。总之，Update方法适合处理瞬时事件，FixedUpdate更适合处理物理相关的事件。
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet,this.transform.position,this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed ;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Jump();
        }
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;
    }
    void FixedUpdate()
    {
        //添加跳跃功能
        // transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        // transform.Rotate(Vector3.up  * hInput * Time.deltaTime);
        //每一帧都生成一个旋转变化量
        Vector3 rotation = Vector3.up * hInput* Time.fixedDeltaTime;
        Quaternion angleRot = Quaternion.Euler(rotation);
        _rigidbody.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        //先应用当前的旋转四元数，再应用指定的旋转四元数
        _rigidbody.MoveRotation(_rigidbody.rotation * angleRot);
        //Debug.Log(IsGrounded());
        //Debug.Log((int)groundLayer);
        
    }
    /// <summary>
    /// 触地检测函数
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        Vector3 bottom = new Vector3(_capsuleCollider.bounds.center.x, _capsuleCollider.bounds.min.y,
            _capsuleCollider.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_capsuleCollider.bounds.center, bottom, 0.2f, groundLayer,
            QueryTriggerInteraction.Ignore);
        return grounded;
    }
    /// <summary>
    /// 跳跃函数
    /// </summary>
    void Jump()
    {
        if (IsGrounded())
        {
            _rigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        
    }

    // void Shoot()
    // {
    //     
    // }
}
