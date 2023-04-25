using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviouor : MonoBehaviour
{
    //
    private Transform patrolRoute;
    public Transform player;
    //一个List用来存放巡逻的路径点transform
    public List<Transform> locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;
    private int _enemyLife = 1;

    public int EnemyLife
    {
        get { return _enemyLife; }
        private set
        {
            _enemyLife = value;
            if (_enemyLife <=0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy killed!");
            }
        }
    }
    private void Start()
    {
        patrolRoute = GameObject.Find("Patrol Route").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextLocation();
    }
//
    void MoveToNextLocation()
    {
        if (locations.Count == 0)
        {
            return;
        }
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
        Debug.Log($"Heading for location No.{locationIndex+1}");
    }
    private void Update()
    {
        if (agent.remainingDistance <= 0.2f && !agent.pathPending)
        {
            MoveToNextLocation();
        }
    }

    void InitializePatrolRoute()
    {
        //遍历了叫patrolRoute 的 Transform 组件的所有子物体，并将它们添加到一个名为 locations 的 List<Transform> 中。
        foreach (Transform transform in patrolRoute)
        {
            locations.Add(transform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player detected! Attack!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            agent.destination = player.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range! Resume patrol!");
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Bullet(Clone)")
        {
            EnemyLife = EnemyLife - 1;
            Debug.Log("Enemy hit");
        }
        
    }
}
