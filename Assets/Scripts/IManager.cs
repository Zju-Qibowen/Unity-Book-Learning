using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager 
{
    public string State { get; set; }
    void Initialize();
}
