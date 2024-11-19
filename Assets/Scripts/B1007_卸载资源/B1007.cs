using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1007 : MonoBehaviour
{
    private Texture tex;


    void Start()
    {
        #region Resources重复加载会浪费内存吗

        //其实Resources加载资源的时候
        //如果资源已经加载过了会一直放在内存中作为缓存
        //第二次加载的时候会直接从缓存中读取
        //所以不会浪费内存
        //但是会浪费性能(每次都需要查找取出)

        #endregion

        #region 释放掉缓存中的资源

        //1.卸载指定资源
        //Resources.UnloadAsset(资源对象);
        //注意：
        //该方法 不能释放 GameObejct 对象 因为它用于实例化对象
        //它只能用于一些 不需要实例化 的资源对象 例如 图片 音频 文本等
        //一般情况下 很少单独使用
        //GameObject obj = Resources.Load<GameObject>("Cube");
        //即使是没有实例化的GameObject也不能卸载
        //Resources.UnloadAsset(obj);


        //2.卸载没有使用的资源
        //注意：
        //一般在切换场景的时候和GC一起使用
        Resources.UnloadUnusedAssets();
        GC.Collect();


        #endregion
    }

    void Update()
    {
        //加载资源
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("加载资源");
            tex = Resources.Load<Texture>("Tex/TestJPG");
        }
        //卸载资源
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("卸载资源");
            Resources.UnloadAsset(tex);
            tex = null;
        }
    }

    private void OnGUI()
    {
        if (tex != null)
        {
            GUI.DrawTexture(new Rect(0, 0, 200, 100), tex);
        }
    }
}
