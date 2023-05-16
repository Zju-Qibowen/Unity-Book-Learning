using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    //声明一个刚体对象
    private Rigidbody2D _rigidbody2D;
    private float _horizontal;
    private float _vertical;
    public float speed = 5f;
    private int _currentHealth;
    public int maxHealth;

    public int HP
    {
        get { return _currentHealth;}
        set
        {
            _currentHealth = value;
            Debug.Log($"当前生命值为{HP}/{maxHealth}。");
        }
    }
    void Start()
    {
        //获取script所在对象的组件方法
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //初始化当前生命值
        _currentHealth = 5;
        
    }
    void Update()
    {
        // //按下左右，会返回-1和1
        // float horizontal = Input.GetAxis("Horizontal");
        // //按下上下，会返回-1和1
        // float vertical = Input.GetAxis("Vertical");
        // //定义一个vector2，用来获取当前物件的position
        // Vector2 n_position = transform.position;
        // n_position.x += speed * horizontal * Time.deltaTime; 
        // n_position.y += speed* vertical* Time.deltaTime;
        // transform.position = n_position;
        // ////开启垂直同步
        // //QualitySettings.vSyncCount = 0;
        // ////设置目标帧数
        // //Application.targetFrameRate = 10;
        
        
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        
        Vector2 position = _rigidbody2D.position;
        position.x += speed * _horizontal * Time.deltaTime;
        position.y += speed * _vertical * Time.deltaTime;
        //下面这个也行
        //_rigidbody2D.position = position;
        _rigidbody2D.MovePosition(position);
    }

    public void ChangeHealth(int amonut)
    {
        //限制生命值取值范围
         HP = Mathf.Clamp(HP + amonut, 0, maxHealth);
        
    }

    
}
