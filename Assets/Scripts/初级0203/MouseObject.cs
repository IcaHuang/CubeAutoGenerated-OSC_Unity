using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseObject : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        var mousePos = Input.mousePosition;
        
        mousePos.z =  gameObject.transform.position.z-Camera.main.transform.position.z;
    
        //屏幕像素空间的二维位置转为三维空间里指定了z坐标的三维位置
       gameObject.transform.position = Camera.main.ScreenToWorldPoint(mousePos); 
    }
}
