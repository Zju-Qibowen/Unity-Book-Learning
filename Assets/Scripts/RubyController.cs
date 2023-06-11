using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RubyController : MonoBehaviour
{
    //声明一个刚体对象
    private Rigidbody2D _rigidbody2D;
    private ProjectileBehaviour projectileBehaviour;
    private float _horizontal;
    private float _vertical;
    public float speed = 5f;
    public int _currentHealth;
    public int maxHealth;
    int initHP = 9;
    
    //设置是否有无敌状态
    public bool isInvincible = false;
    //声明一个animator
    private Animator animator;
    
    //有一个可以发射的子弹预制件
    public GameObject bulletPrefab;
    private GameObject bullet;
    
    //有一个朝向的方向
    private Vector2 lookDirection;
    
    //有一个子弹发射冷却时间和是否冷却的bool
    private bool isLaunchCoolDown = false;
    public float defaultCoolDownTime = 1f;
    private float curCoolDownTime = 0f;
    
    //定义一个协程，2s的无敌
    public IEnumerator InvincibilityCoroutine()
    {
        //animator.SetBool("isHit",true);
        isInvincible = true;
        yield return new WaitForSeconds(2f);
        isInvincible = false;
        //animator.SetBool("isHit",false);
    }
    public int HP
    {
        //get为取值器
        get { return _currentHealth;}
        //set为赋值器
        set
        {
            _currentHealth = value;
            Debug.Log($"当前生命值为{HP}/{maxHealth}。");
            UIHealthBar.Instance.SetValue(_currentHealth/(float)maxHealth);
            if (HP >= maxHealth)
            {
                Debug.Log("HP已满！");
            }
            if (HP <= 0)
            {
                Debug.Log("血条空了！");
            }
        }
    }
    
    void Start()
    {
        //获取script所在对象的组件方法
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //初始化当前生命值
        HP = initHP;
        animator = GetComponent<Animator>();

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
        
        if (_horizontal > 0)
        {
            lookDirection=Vector2.right;
            animator.SetFloat("LookX", 1f);
            animator.SetFloat("LookY", 0f);
        }
        else if (_horizontal < 0)
        {
            lookDirection=Vector2.left;
            animator.SetFloat("LookX", -1f);
            animator.SetFloat("LookY", 0f);
        }
        else if (_vertical > 0)
        {
            lookDirection=Vector2.up;
            animator.SetFloat("LookX", 0f);
            animator.SetFloat("LookY", 1f);
        }
        else if (_vertical < 0)
        {
            lookDirection=Vector2.down;
            animator.SetFloat("LookX", 0f);
            animator.SetFloat("LookY", -1f);
        }
        else
        {
            // 如果没有输入，可以根据需要设置默认动画
        }
        //设置Speed的值
        animator.SetFloat("Speed", Mathf.Max(Mathf.Abs(_vertical),Mathf.Abs(_horizontal))); // 垂直
        
        //如果不在冷却，按下按键发射飞弹
        if (!isLaunchCoolDown)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                animator.SetTrigger("isLaunch");
                RubyLaunchBullet();
                isLaunchCoolDown = true;
            }
        }
        //如果在冷却，冷却时间慢慢缩减
        else
        {
            curCoolDownTime -= Time.deltaTime;
            if (curCoolDownTime <= 0)
            {
                isLaunchCoolDown = false;
                curCoolDownTime = defaultCoolDownTime;
            }
        }
        
        //发射射线检测对话
        if (Input.GetKeyDown(KeyCode.X))
        {
            LayerMask npcLayerMask = LayerMask.GetMask("NPC");
            //创建一个2d射线，返回hit
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(_rigidbody2D.position.x,_rigidbody2D.position.y+0.2f),lookDirection,1.5f,npcLayerMask);
            if (hit.collider != null)
            {
                Debug.Log("射线命中");
            }
        }
        
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
    public void AddHealth(int amonut)
    {
        //限制生命值取值范围
         HP = Mathf.Clamp(HP + amonut, 0, maxHealth);
        
    }
    //如果扣血则调用此方法
    public void MinusHealth(int amonut)
    {
        //在此方法里检测是否无敌
        if (HP >0 && !isInvincible)
        {
            animator.SetTrigger("isHit");
            //限制生命值取值范围
            HP = Mathf.Clamp(HP - amonut, 0, maxHealth);
            StartCoroutine(InvincibilityCoroutine());
        }
        else if (isInvincible)
        {
            Debug.Log("Player is invincible!");
        }

    }

    void RubyLaunchBullet()
    {
        bullet = Instantiate(bulletPrefab,_rigidbody2D.position+new Vector2(0,0.5f),Quaternion.identity);
        projectileBehaviour = bullet.GetComponent<ProjectileBehaviour>();
        projectileBehaviour.GenerateBullet(lookDirection,projectileBehaviour.launchForce);
    }
    
}
