using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class B1002 : MonoBehaviour
{
    Thread t = null;

    //申明一个变量作为一个公共容器
    Queue<Vector3> queue = new Queue<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        #region Unity支持多线程

        //但是新线程不能访问Unity内的相关内容
        //记得销毁

        t = new Thread(Test);
        t.Start();

        #endregion

        #region 协同程序

        //将代码分时执行不卡主线程
        //假的多线程，不是多线程

        //主要作用
        //将代码分时执行,不卡主线程
        //将可能导致主线程卡顿的耗时逻辑分步执行

        //主要使用场景
        //异步加载文件
        //异步下载文件
        //场景异步加载
        //批量创建时防止卡顿


        #endregion

        #region 协同程序和线程的区别

        //新开的线程是一个独立的管道，和主线程并行
        //新开的协同程序实在原线程上开启，进行逻辑的分时执行

        #endregion

        #region 协程的使用

        //继承Mono类 都可以开启
        //第一步：声明协程函数
        // 两个关键点：1-1返回值IEnumerator类型及其子类
        //            1-2函数中通过 yield return 返回值; 进行返回

        //第二步：开启协程函数
        //协程函数不能直接执行!!!!!!!不会有任何效果!!!!!!
        IEnumerator ie = MyCoroutine(1, "123");
        //常用开启方式
        Coroutine c1 = StartCoroutine(MyCoroutine(1, "123"));
        Coroutine c2 = StartCoroutine(ie);
        Coroutine c3 = StartCoroutine(MyCoroutine(1, "123"));


        //第二步：关闭协程函数
        //关闭所有协程函数
        //StopAllCoroutines();
        //关闭指定协程函数
        StopCoroutine(c1);
        //StopCoroutine(c2);
        //StopCoroutine(c3);

        #endregion

        #region yield return 的不同含义的执行内容

        //1下一帧执行
        //yield return 数字;
        //yield return null;
        //在Update和LateUpdate之间执行

        //2等待指定秒后执行
        //yield return new WaitForSeconds(秒);
        //在Update和LateUpdate之间执行

        //3等待下一个固定物理帧更新执行
        //yield return new WaitForFixedUpdate();
        //在FoxUpdate和碰撞检测相关函数执行之后执行

        //4等待摄像机和GUI渲染完成之后执行
        //yield return new WaitForEndOfFrame();
        //在lateUpdate之后的相关渲染完毕之后执行

        //5一些特殊类型的对象 比如异步加载相关函数返回值的对象
        //之后讲解 异步加载资源 异步加载场景 网络加载   
        //一般在Update和LateUpdate之间执行

        //6跳出协程
        //yield break;

        #endregion

        #region 协程的执行与失活

        //协程开启后 
        //脚本和物体销毁，协程不执行
        //物体失活协程不执行,脚本失活协程不影响

        #endregion
    }


    void Update()
    {
        if (queue.Count > 0)
        {
            this.transform.position = queue.Dequeue();
        }
    }

    //关键点一 协同程序返回值 返回值必须是IEnumerator或者其他继承类型
    IEnumerator MyCoroutine(int i, string str)
    {
        print(i);
        //关键点二 协程函数中 必须使用 yield return 进行返回
        //yield return 进行分布
        yield return new WaitForSeconds(5f);//等待5s
        print(str);
        yield return new WaitForFixedUpdate();
        print("1");
        //用来截图时使用
        yield return new WaitForEndOfFrame();

        //yield break;

        while(true)
        {
            print("666");
            yield return new WaitForSeconds(5f);
        }
    }


    private void Test()
    {
        while(true)
        {
            Thread.Sleep(1000);
            //相当于模拟复杂算法，放入公共容器中
            System.Random r = new System.Random();
            queue.Enqueue(new Vector3(r.Next(-10,10), r.Next(-10,10), r.Next(-10,10)));
            print("123");
        }
    }

    private void OnDestroy()
    {
        t.Abort();
        t= null;
    }

}
