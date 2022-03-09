using UnityEngine;
using uOSC;

public class OscReceiveTest : MonoBehaviour
{
    public uOscServer receiver;
    // Start is called before the first frame update
    void Start()
    {
        receiver.onDataReceived.AddListener(OnDataReceived);
    }


    void OnDataReceived(Message message)
    {
        //把消息头加入要在控台输入的变量里
        var msg = message.address + ": ";

        //检查收到的信息里的每一个单位，对照类型累加输出到控台
        foreach(var value in message.values)
        {
            if (value is int) msg += (int)value;
            else if (value is float) msg += (float)value;
            else if (value is string) msg += (string)value;
            else if (value is byte[]) msg += "byte[" + ((byte[])value).Length + "]";
        }

        //输出到控制台
        Debug.Log(msg);
    }
}
