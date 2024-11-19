using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourcesMgr
{
    private static ResourcesMgr instance = new ResourcesMgr();
    public static ResourcesMgr Instance => instance;

    private ResourcesMgr()
    {

    }

    public void LoadRes<T>(string name, UnityAction<T> callBack) where T: Object
    {
        ResourceRequest rq = Resources.LoadAsync<T>(name);
        rq.completed += (a) =>
        {
            //直接得到 传入的 对象 通过它得到对应类型 直接传出去 外面不需要转换直接使用
            callBack((a as ResourceRequest).asset as T);
        };
    }

}
