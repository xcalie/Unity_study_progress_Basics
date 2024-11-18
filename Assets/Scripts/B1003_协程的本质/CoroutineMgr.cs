using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class YieldReturnTime
{
    //记录下一次还要执行的 迭代器接口
    public IEnumerator ie;
    //记录下次执行的时间点
    public float time;
}



public class CoroutineMgr : MonoBehaviour
{
    private static CoroutineMgr instance;

    public static CoroutineMgr Instance => instance;

    //申明存储迭代器的变量，用于下一次执行
    private List<YieldReturnTime> list = new List<YieldReturnTime>();


    private void Awake()
    {
        instance = this;
    }


    public void MyStartCoroutine(IEnumerator ie)
    {
        //来进行 分步走 分时间执行逻辑

        //传入一个 迭代器函数返回结构 那么应该一来就执行
        //一来就执行第一步 执行完了 如果返回 返回的true 证明后面还有步骤
        if (ie.MoveNext())
        {
            //判断 如果yield return 返回的 数字 是一个int类型 那就证明 等待n秒才能运行
            if (ie.Current is int)
            {
                //按思路 应该 把迭代器下一次执行的时间店记录下来
                //然后不停的检测 时间 是否达到了下一次执行的 时间点 然后继续执行它
                YieldReturnTime y = new YieldReturnTime();
                //记录迭代器接口
                y.ie = ie;
                //记录时间
                y.time = Time.time + (int)ie.Current;
                //把记录的信息记录到数据容器当中 以为可能有多个协程函数开启 所以 用一个list存储
                list.Add(y);
            }
        }
    }

    private void Update()
    {
        //为了避免循环的时候 从列表中删除元素导致 所以从前往后遍历
        for (int i = list.Count - 1; i >= 0; i--)
        {
            //判断 当前迭代器函数 是否到了执行函数下一步的时间
            //如果到了就执行下一步
            if (list[i].time <= Time.time)
            {
                if (list[i].ie.MoveNext())
                {
                    //如果是true 那还需要对该迭代器函数 进行处理
                    //如果是 int类型 证明需要等待n秒
                    if (list[i].ie.Current is int)
                    {
                        list[i].time = Time.time + (int)list[i].ie.Current;
                    }
                    else
                    {
                        //该list只是存储 处理时间相关的 等待逻辑的 迭代器函数
                        //如果是别的类型 就不应该放入这个list总（因为这个list只存储等待时间的函数）
                        list.RemoveAt(i);
                    }
                }
                else
                {
                    //如果勾选没有可以等待和执行的函数  就证明这个协程函数执行完了
                    list.RemoveAt(i);
                }

            }
        }
    }
}
