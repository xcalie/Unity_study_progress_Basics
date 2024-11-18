using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1001_execrcise : MonoBehaviour
{
    private int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        #region 利用延迟函数实现计秒器

        //InvokeRepeating("DelayFun", 0, 1);
        DelayFun2();

        #endregion

        #region 用两种方式销毁一个指定对象

        //通过Destroy销毁
        Destroy(this.gameObject, 5);

        //通过延迟函数调用函数
        Invoke("DesDelay", 5);

        #endregion
    }

    private void DesDelay()
    {
        Destroy(this.gameObject);
    }

    private void DelayFun()
    {
        print(time + "秒");
        ++time;
    }

    private void DelayFun2()
    {
        print(time + "秒");
        ++time;
        Invoke("DelayFun2", 1);
    }
}
