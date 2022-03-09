using UnityEngine;

[RequireComponent(typeof(CloneId))]
public class PositionFromID : MonoBehaviour
{
    public float scaler = 1.0f;
    public float translate = 0.0f;


    //public enum MyEnum
    //{
    //    x,y,z,all
    //}
    //public MyEnum axis;


    // Start is called before the first frame update
    void Start()
    {
        setPosition();
        if (GetComponent<CloneId>().isCenter)
        {
            changeCameraPos();
        }
    }

    void OnValidate()
    {
        if (Application.isPlaying)
        {
            setPosition();
        }
    }

    void setPosition()
    {
        var id = gameObject.GetComponent<CloneId>();

        transform.position =
            new Vector3(id.xValue * scaler + translate, id.yValue * scaler + translate, id.zValue * scaler + translate);
    }

    void changeCameraPos()
    {
        var camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        
        
        camera.transform.position =
            new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        
    }
}
