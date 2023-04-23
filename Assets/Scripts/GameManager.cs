using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IManager
{
    /// <summary>
    /// 有两个属性。
    /// </summary>
    private int _itemCollected = 0;
    private int _playerHp = 5;
    public string labelText;
    public int maxItems = 4;
    public bool winGame = false;
    public bool loseGame = false;
    public string _stage;
    
    public string State
    {
        get { return _stage; }
        set { _stage = value; }
    }

    public void Initialize()
    {
        State = "Manager Initialized!";
        Debug.Log("State");
    }
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
                winGame = true;
                Time.timeScale = 0f;
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
            if (_playerHp ==0)
            {
                labelText = "You lose!";
                loseGame = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "You got hurt!";
            }
        }
    }

    private void Start()
    {
        labelText = "Collect 4 items to win this game!";
        
    }

    // void RestartLevel()
    // {
    //     SceneManager.LoadScene(0);
    //     Time.timeScale = 1f;
    // }
    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25),$"Player Health:{_playerHp}");
        GUI.Box(new Rect(20, 50, 150, 25),$"Items Collected:{_itemCollected}");
        GUI.Label(new Rect(Screen.width/2-100,Screen.height-50,300,50),labelText);
        
        //赢得游戏时弹出
        if (winGame)
        {
            if (GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-50,200,100),"You win!"))
            {
                Utilities.RestartLevel();

            }
        }
        //输了游戏时弹出
        if (loseGame)
        {
            if (GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-50,200,100),"You lose!"))
            {
                Utilities.RestartLevel();
            }
        }
    }
}
