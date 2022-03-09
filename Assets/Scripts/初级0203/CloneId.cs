using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CloneId : MonoBehaviour
{
    [HideInInspector]//属性栏上不要显示
    public int xValue;//用来存储序号
    [HideInInspector]
    public int yValue;
    [HideInInspector]
    public int zValue;
    [HideInInspector]
    public bool isCenter = false;
}
