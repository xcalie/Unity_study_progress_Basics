using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B1008 : MonoBehaviour
{

    void Start()
    {
        #region 场景同步切换

        //同步切换会直接将场景上的对其全部删除，并一起添加新场景的东西
        //可能会导致卡顿
        SceneManager.LoadScene("B1008Test");

        #endregion

        #region 场景异步切换

        //场景异步加载和资源异步加载几乎相同

        //1通过时间回调函数 异步加载
        AsyncOperation ao = SceneManager.LoadSceneAsync("B1008Test");
        //当场景异步加载完之后 会自动调用该函数 如果希望在加载完之后做一些事情
        //就可以在改函数中写处理逻辑
        ao.completed += (a) =>
        {
            print("加载结束");
        };

        ao.completed += LoadOver;



        //2通过协程异步加载
        //需要注意的是 加载场景会把当前场景上 没有特别处理的对象 都删除了
        //所以 协程中部分逻辑 可能是执行不了的
        //解决思路
        //让处理场景加载的脚步依附的对象 在切换时不删除

        //避免依附对象删除
        DontDestroyOnLoad(this.gameObject);

        StartCoroutine(LoadSence("B1008Test"));


        #endregion
    }

    private void LoadOver(AsyncOperation ao)
    {
        print("LoadOver");
    }

    IEnumerator LoadSence(string name)
    {
        //第一步
        //异步加载场景
        AsyncOperation ao = SceneManager.LoadSceneAsync("B1008Test");
        //Unity内部的协程处理器 会处理对应返回类型 等待异步加载
        //加载完之后 才会执行下一部分
        print("异步加载过程中打印的信息");
        //协程的好处 可以在加载过程中处理其他逻辑
        yield return ao;
        //第二步
        print("异步加载结束后打印的信息");
    }
}
