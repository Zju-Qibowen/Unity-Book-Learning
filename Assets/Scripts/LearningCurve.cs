 using System;
 using System.Collections;
using System.Collections.Generic;
 using Unity.VisualScripting;
 using UnityEngine;

public class LearningCurve : MonoBehaviour
{

    public Transform transform;
    public Transform dlTransform;
    public GameObject directionLight;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        //Debug.Log(transform.position);
        //可以直接用拖动对象来代替Find；Find要求命名必须唯一。
        directionLight = GameObject.Find("Directional Light");
        dlTransform = directionLight.GetComponent<Transform>();
        Debug.Log(dlTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
