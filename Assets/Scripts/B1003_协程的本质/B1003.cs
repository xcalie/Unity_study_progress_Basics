using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestClass
{
    public float time;

    public TestClass()
    { 
    }

    public TestClass(float time)
    {
        this.time = time;
    }
}



public class B1003 : MonoBehaviour
{
    IEnumerator Test()
    {
        print("第一次执行");
        yield return 1;
        print("第二次执行");
        yield return 2;
        print("第三次执行");
        yield return "123";
        print("第四次执行");
        yield return new TestClass(10);
    }


    // Start is called before the first frame update
    void Start()
    {
        #region 协程的本质

        //协程可以分成两部分
        //1协程本体 
        //2协程调度器

        //协程本体就是一个可以中间暂停返回的函数
        //协程调度器是Unity内部实现的，会在对应时机帮助我们继续执行协程函数

        //Unity只实现了协程调度的部分
        //协程的本体本质上就是一个C#的迭代器方法

        #endregion

        #region 协程本体是迭代器方法的实现

        //1协程函数本体
        //如果不通过 开启协程方法执行协程
        //Unity内部协程调度器不会自动进行迭代器调度
        IEnumerator ie = Test();

        //可以自行执行迭代器函数内容
        //ie.MoveNext();//会执行到yield return为止的逻辑
        //print(ie.Current);//得到yield return返回的内容

        //ie.MoveNext();
        //print(ie.Current);

        //ie.MoveNext();
        //print(ie.Current);

        //ie.MoveNext();
        //TestClass tc = ie.Current as TestClass;
        //print(tc.time);

        //MoveNext的返回值 代表着是否到了结尾（这个迭代器函数是否执行完毕)
        while(ie.MoveNext())
        {
            print(ie.Current);
        }


        //2协程调度器
        //继承Mono后开启协程
        //相当于把一个协程函数(迭代器)放入 Unity的协程调度器中帮助我们管理
        //具体的yield return 后面的规则 也是untiy定义的一些规则



        #endregion
    }

    // Update is called once per frame
    void Update()   
    {
        
    }
}
