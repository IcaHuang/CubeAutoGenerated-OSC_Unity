using UnityEngine;
using uOSC;

public class OscSendTest : MonoBehaviour
{
    //发送OSC消息的对象
    public uOscClient sender;

    // Update is called once per frame
    void Update()
    {
        //如果安下了鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
            sender.Send("/oscAddress",180,"PI",3.14f, new byte[] {1, 2, 3, 4});
        }
    }
}
