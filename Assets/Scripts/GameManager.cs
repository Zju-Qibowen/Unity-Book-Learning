using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 有两个属性。
    /// </summary>
    private int _itemCollected = 0;
    private int _playerHp = 10;
    public string labelText;
    public int maxItems = 4;
    public int ItemCollected
    {
        get { return _itemCollected; }
        //如果没有setter方法，则这个属性是只读的。
        set
        {
            _itemCollected = value;
            if (_itemCollected >= maxItems)
            {
                labelText = "You have found all items!";
            }
            else
            {
                labelText = $"Item found, but you need to find {maxItems -_itemCollected} more items!";
            }
        }
    }
    public int PlayerHp
    {
        get { return _playerHp; }
        ////如果没有setter方法，则这个属性是只读的。
        set
        {
            _playerHp = value; 
            Debug.LogFormat("HP: {0}",_playerHp);
        }
    }

    private void Start()
    {
        labelText = "Collect 4 items to win this game!";
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25),$"Player Health:{_playerHp}");
        GUI.Box(new Rect(20, 50, 150, 25),$"Items Collected:{_itemCollected}");
        GUI.Label(new Rect(Screen.width/2-100,Screen.height-50,300,50),labelText);
    }
}
