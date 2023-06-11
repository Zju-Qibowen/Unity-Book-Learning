using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    //创建共有的静态成员
    public static UIHealthBar Instance { get; private set; }
    public Image mask;
    private float originalSize;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //获取mask的宽度值
        originalSize = mask.rectTransform.rect.width;
    }
    
    //创建一个方法用来设置实时的宽度
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalSize * value);
    }
}
