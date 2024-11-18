using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class B1003_execrcise : MonoBehaviour
{


    void Start()
    {
        //Unity自带的协同程序管理器
        //StartCoroutine(MyTest());

        CoroutineMgr.Instance.MyStartCoroutine(MyTest());
    }


    IEnumerator MyTest()
    {
        print("1");
        yield return 1;
        print("2");
        yield return 2;
        print("3");
        yield return 3;
    }
}
