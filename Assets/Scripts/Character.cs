using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name = "daddy";
    public int exp = 0;
    //构造函数1
    public Character(string name)
    {
        this.name = name;
    }
    //构造函数2
    public Character()
    {
        name = "Not Assigned";
    }
    public void PrintStatsInfo()
    {
        Debug.LogFormat("Hero: {0} - Exp: {1}",name,exp);
    }
    private void Reset()
    {
        this.name = "Not Assigned";
        this.exp = 0;
    }
    //下面等价
    // public float GetBMI(float h, float w)
    // {
    //     return w / (h * h);
    // }
    
    public float GetBMI(float h, float w) => w / (h*h);
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
