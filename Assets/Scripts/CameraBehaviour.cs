using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0, 1.2f, -2.6f);
    private Transform playerTransform;
    void Start()
    {
        //拿到玩家的位置
        playerTransform = GameObject.Find("Player").transform;
    }

    
    void LateUpdate()
    {
        this.transform.position = playerTransform.TransformPoint(camOffset);
        this.transform.LookAt(playerTransform);
    }
}
