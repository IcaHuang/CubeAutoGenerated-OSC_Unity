using uOSC;
using UnityEngine;

public class receiveTouchOscXY : MonoBehaviour
{
    public uOscServer receiver;
    private uOscServer instanceReceiver;
    // Start is called before the first frame update
    void Start()
    {
        instanceReceiver = Instantiate(receiver, Vector3.zero, Quaternion.identity);
        instanceReceiver.onDataReceived.AddListener(OnDateReceived);
    }

    void OnDateReceived(Message message)
    {
        //判断消息头是否正确
        if(message.address == "/3/xy")
        {
            //将收到的x、y值分别映射到新的范围上
            var x = Remap((float)message.values[0], 0f, 1f, 0f, 14f);
            var y = Remap((float)message.values[1], 0f, 1f, 7f, 0.0f);
            //赋值到对象的坐标上
            gameObject.transform.position = new Vector3(x, y, 0);
        }


        ////以下用于打印收到的信号
        //把消息头加入要在控台输入的变量里
        var msg = message.address + ": ";

        //检查收到的信息里的每一个单位，对照类型累加输出到控台
        foreach (var value in message.values)
        {
            if (value is int)
            {
                msg += (int)value;
                msg += ", ";
            }
            else if (value is float)
            {
                msg += (float)value;
                msg += ", ";
            }
            else if (value is string)
            {
                msg += (string)value;
                msg += ", ";
            }
            else if (value is byte[])
            {
                msg += "byte[" + ((byte[])value).Length + "]";
                msg += ", ";
            }
        }

        //输出到控制台
        Debug.Log(msg);
    }

    float Remap(float x, float x1, float x2, float y1, float y2)
    {
        var m = (y2 - y1) / (x2 - x1);
        var c = y1 - m * x1;
        return m * x + c;
    }
}
