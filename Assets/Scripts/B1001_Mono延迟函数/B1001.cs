using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1001 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 延迟函数

        //延迟执行的函数
        //自行设定执行延迟时间和重复间隔时间
        //是Mono基类中已经实现好的方法

        #endregion

        #region 使用

        //1延迟函数
        //Invoke
        //参数一：函数名（字符串）
        //参数二：延迟秒数
        Invoke("DelayDonSomething", 5);

        //注意
        //由于只能传入字符串搜索函数名，所有只能带入无参数函数，可以有返回值
        //第一个字符串传入的是函数名
        //只能在当前脚本进行搜索


        //2延迟重复执行的函数
        //InvokeRepeating
        //参数一：函数名（字符串）
        //参数二：第一次执行函数的时间
        //参数二：第一次执行函数之后重复执行的间隔
        InvokeRepeating("DelayDonSomething", 5, 3);


        //3取消延迟函数
        //3-1取消当前脚本上所有的延迟函数
        //CancelInvoke();

        //3-2指定函数名取消
        //CancelInvoke("DelayDonSomething");

        //4判断是否有延迟函数
        if (IsInvoking("DelayDonSomething"))
        {
            Debug.Log("存在DelayDonSomething延迟函数");
        }
        else
        {
            Debug.Log("不存在该DelayDonSomething延迟函数");
        }

        #endregion

        #region 延迟函数执行

        //挂载对象被移除,或者脚本被移除
        //就不会执行

        //仅仅是对象失活，或者脚本失活
        //仍然会执行

        #endregion
    }

    private void OnEnable()
    {
        //对象激活 的生命周期函数中 开启延迟 (重复执行的过程)
        Invoke("DelayDonSomething", 3);
        InvokeRepeating("DelayDonSomething", 3, 6);
    }

    private void OnDisable()
    {
        //对象失活 的生命周期函数中 关闭延迟
        CancelInvoke();
    }

    private void DelayDonSomething()
    {
        Debug.Log("延迟执行");
    }

    private void process(int num)
    {
        Debug.Log("发生的某事" + num);
    }
}
