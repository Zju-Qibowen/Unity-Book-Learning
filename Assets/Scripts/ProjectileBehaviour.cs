using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectileBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public Vector2 direction;
    [FormerlySerializedAs("force")] public float launchForce;
    private EnemyController _enemyController;
    
    // Start is called before the first frame update
    void Start()
    {
        //在start的时候无法顺利初始化
        //_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction,float force)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(direction*force,ForceMode2D.Force);
        Destroy(this.gameObject,3f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBot"))
        {
            _enemyController = other.gameObject.GetComponent<EnemyController>();
            if (_enemyController != null)
            {
                _enemyController.Fix();
                Destroy(this.gameObject);
            }
            
        }
    }
}
