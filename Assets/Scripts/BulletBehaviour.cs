using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float delayTime = 3f;
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject,delayTime);
    }
}
