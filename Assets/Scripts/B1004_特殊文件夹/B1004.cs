using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1004 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 工程路径的获取

        //注意该方式 获取到的路径 一般情况下 只在编辑模式下 使用
        //我们不会再实际发布游戏后 还是用该路径
        //游戏发布过后该路径就不存在了
        print(Application.dataPath);

        #endregion

        #region Resources 资源文件夹

        //路径获取
        //一般不获取
        //只能使用Resources相关的API进行加载
        //如果硬要获取 可以用工程路径拼接
        print(Application.dataPath + "/Resources");

        //注意：
        //需要我们自己创建
        //作用：
        //资源文件夹
        //1-1.需要通过Resources相关的API动态加载的资源需要放在其中
        //1-2.该文件夹下所有文件都会被打包出去
        //1-3.打包时Unity会对其压缩加密
        //1-4.该文件夹打包后只读，只能通过Resources相关API加载

        #endregion

        #region StreamingAssets 流动资源文件夹

        //路径获取
        //print(Application.dataPath + "/StreamingAssets");//避免这种打包后路径不对
        print(Application.streamingAssetsPath);

        //注意:
        //需要我们自己创建
        //作用:
        //流文件夹
        //2-1.打包出去不会被压缩加密，可以随意使用
        //2-2.移动平台只读,PC平台可读写
        //2-3.可以放入一些需要自定义动态加载的资源

        #endregion

        #region persistentDataPath 持久化数据文件夹

        //路径获取
        print(Application.persistentDataPath);

        //注意:
        //不需要我们创建
        //作用:
        //固定数据文件夹
        //3-1.所有普通可读可写
        //3-2.一般用于放置动态下载或者动态创建的文件，游戏中创建或在获取的文件夹都放在其中

        #endregion

        #region Plugins 插件文件夹

        //路径获取:
        //一般不获取

        //注意:
        //需要我们自己创建
        //作用:
        //插件文件夹
        //不同平台的插件相关文件放在其中
        //比如Android平台的.so文件，IOS平台的.a文件

        #endregion

        #region Editor  编辑器文件夹

        //路径获取:
        //一般不获取
        //如果硬要获取 可以用工程路径拼接
        print(Application.dataPath + "/Editor");

        //注意:
        //需要我们自己创建
        //作用:
        //5-1:开发Unity编辑器，编辑器相关的脚步放在该文件夹中
        //5-2:该文件夹下的脚本不会被打包出去

        #endregion

        #region 默认资源文件夹 Standard Assets

        //路径获取:
        //一般不获取

        //注意:
        //需要我们自己创建
        //作用:
        //默认资源文件夹
        //一般Unity自带的资源文件夹都放在这个文件夹下
        //代码和资源优先被编译

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
