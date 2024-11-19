using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1006 : MonoBehaviour
{
    public Texture tex;


    void Start()
    {
        #region Resources异步加载是什么

        //如果进行了大量同步加载资源，会导致卡顿
        //卡顿的原因就是 从硬盘上把数据读取到内存中 是需要进行计算的
        //越到的资源耗时越长，就会造成卡顿掉帧

        //Resources异步加载 就是内部新开一个线程进行资源加载，不会影响主线程的运行

        #endregion

        #region Resources异步加载的方法

        //注意：
        //异步加载 不能马上得到加载的资源 至少要等一帧

        //通过异步加载中完成事件监听 使用加载的资源
        //这句代码 你可以理解 Unity 在内部 就会去开个线程进行资源下载
        ResourceRequest rq = Resources.LoadAsync<Texture>("Tex/TestJPG");
        //马上进行一个 资源下载结束 的一个事件函数监听
        //rq.completed += LoadOver;
        ////print(Time.frameCount);

        //这个 刚刚执行了异步加载的 执行代码 资源还没有加载完毕 这样用 是不对的
        //一定要等待加载结束过后 才能使用
        //rq.asset 不能这样用！！！！！！！！！！！！！

        //通过协程 使用加载资源
        StartCoroutine(Load());

        #endregion

        #region 总结

        //1.完成事件监听异步加载
        //好处：写法简单
        //坏处：只能在加载完毕后使用资源 进行处理
        //“线性加载”

        //2.协程异步加载
        //好处：可以在协程中处理复杂逻辑，比如同时加载多个资源，比如进度条跟新
        //坏处：写法复杂
        //“并行加载”

        //注意：
        //理解为什么异步加载不能马上加载结束，为什么至少要等一帧
        //理解协程异步加载的原理

        #endregion
    }

    private void LoadOver(AsyncOperation rq)
    {
        print("加载结束");
        //asset 是资源对象 加载完毕过后 就能得到它
        tex = (rq as ResourceRequest).asset as Texture;
    }


    IEnumerator Load()
    {
        //迭代器函数 当遇到yield return时 就会停止执行之后的代码
        //然后 协程调度器 通过得到 返回的值 去判断 下一次执行后面的步骤 将会是何时
        ResourceRequest rq = Resources.LoadAsync<Texture>("Tex/TestJPG");
        print(Time.frameCount);
        //第一部分
        //Unity 有协程调度器 指定这个类型的返回值 就是在异步加载资源
        yield return rq;
        //Unity 会自行判断 该资源是否加载完毕 如果加载完毕 就会执行下面的代码
        print(Time.frameCount);
        //tex = rq.asset as Texture;
        //判断资源是否加载完毕
        while(!rq.isDone)
        {
            //打印当前 加载进度
            //改进度不会 特别准确 过度也不是特别明显
            print(rq.progress);
            yield return null;
        }
        tex = rq.asset as Texture;


        //yield return null;
        ////第二部分
        //yield return new WaitForSeconds(2f);
        ////第三部分
    }


    private void OnGUI()
    {
        if (tex != null)
        {
            GUI.DrawTexture(new Rect(0, 0, 200, 100), tex);
        }
    }
}
