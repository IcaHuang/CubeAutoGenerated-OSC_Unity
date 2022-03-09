using UnityEngine;
[RequireComponent(typeof(Renderer))]
public class RandomLitColor : MonoBehaviour
{
    public enum ShaderType
    {
        light,unLight
    }

    public ShaderType shaderType;
    void Start()
    {
        //随机生成一个颜色
        Color randomColor = Random.ColorHSV();
        if (shaderType==ShaderType.light)
        {
            //设置到litShader上
            gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", randomColor);
        }
        else if (shaderType==ShaderType.unLight)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", randomColor);
        }

    }
    
    void Update()
    {
        
    }
}
