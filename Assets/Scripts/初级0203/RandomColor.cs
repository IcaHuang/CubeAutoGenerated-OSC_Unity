using UnityEngine;
[RequireComponent(typeof(Renderer))]
public class RandomColor : MonoBehaviour
{
    void Start()
    {
        //随机生成一个颜色
        Color randomColor = Random.ColorHSV();
        
        GetComponent<Renderer>().material.SetColor("_Color", randomColor);
    }
    
}
