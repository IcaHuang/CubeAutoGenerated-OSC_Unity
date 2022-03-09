using System;
using UnityEngine;
using System.Collections.Generic;

public class Cloner : MonoBehaviour
{
    //被克隆的对象
    public GameObject cloneObj;
    [SerializeField]
    private int xCount = 8;
    [SerializeField]
    private int yCount = 4;

    //当前帧结束的时候用来存储count的值
    private int priorXCount;
    private int priorYCount;

    //数组列表，用来存储克隆出来的对象
    private List<List<GameObject>> theClones;

    public bool asChildren;
    void Start()
    {
        //theClones = new List<GameObject>();

        theClones = new List<List<GameObject>>();
        
        //for (int i = 0; i < 100; i++)
        //{
        //    theClones.Add(new List<GameObject>());
        //}

        //克隆对象操作放入一个自定义函数，方便二次调用
        Initialize();
    }

    private void Update()
    {
        //比较count的值和上一帧比有没有发生变化
        if (priorXCount != xCount)
        {
            reSet(); 
        }
        priorXCount = xCount;

        if (priorYCount != yCount)
        {
            reSet();
        }
        priorYCount = yCount;
    }

    //当脚本会挂载在对象上的时候，还有脚本的输入参数发生变化的时候
    //此函数才被调用
    //  void OnValidate()
    // {
    //     //场景运行的时候才执行if里的内容
    //     if (Application.isPlaying)
    //     {
    //         reSet();
    //     }
    // }


     void reSet()
     {
        if (theClones == null)
        {
            theClones = new List<List<GameObject>>();
            Initialize();
            return;
        }

        foreach (var list in theClones)
        {
             foreach (var obj in list)
            {
                Destroy(obj);
            }
         }

         theClones.Clear();
         Initialize();
     }

     void Initialize()
     {
        for (int i = 0; i < yCount; i++)
        {
            GameObject temObject = null;
            List<GameObject> listObject = new List<GameObject>();

            for (int j = 0; j < xCount; j++)
            {
                if (asChildren)
                {
                    //克隆函数的参数：克隆对象，位置，朝向
                    temObject = Instantiate(cloneObj, Vector3.zero, Quaternion.identity, transform);
                }
                else
                {
                    temObject = Instantiate(cloneObj, Vector3.zero, Quaternion.identity);
                }

                temObject.GetComponent<CloneId>().xValue = j;
                temObject.GetComponent<CloneId>().yValue = i;
                temObject.GetComponent<CloneId>().zValue = 0;
                if (i == yCount / 2 && j == xCount / 2)
                {
                    temObject.GetComponent<CloneId>().isCenter = true;
                }
                listObject.Add(temObject);
            }

            theClones.Add(listObject);
        }

        
    }
}


