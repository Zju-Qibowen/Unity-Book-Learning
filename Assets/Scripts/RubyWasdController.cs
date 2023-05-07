using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyWasdController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        Vector2 n_position = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            n_position.y += 0.01f;
        }
        
        if (Input.GetKey("s"))
        {
            n_position.y -= 0.01f;
        }
        
        if (Input.GetKey("a"))
        {
            n_position.x -= 0.01f;
        }
        
        if (Input.GetKey("d"))
        {
            n_position.x += 0.01f;
        }

        transform.position = n_position;
    }
}
