using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform lookAtObj;
    static private Transform cloned;
    
    void Start()
    {
        // 单例模式
        if (cloned == null)
        {
            cloned = Instantiate(lookAtObj, Vector3.zero, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(cloned);
    }
}
