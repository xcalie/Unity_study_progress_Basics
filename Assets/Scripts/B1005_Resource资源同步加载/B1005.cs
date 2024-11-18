using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1005 : MonoBehaviour
{
    public AudioSource AudioS;

    public Texture tex;


    // Start is called before the first frame update
    void Start()
    {
        #region Resource资源动态同步加载

        //1.通过代码动态加载Resources文件夹路径下的资源
        //2.避免繁琐的拖曳操作

        #endregion

        #region 常用资源类型

        //1.预设体对象——GameObject
        //2.音效文件——AudioClip
        //3.文本文件——TextAsset
        //4.图片文件——Texture
        //5.其他文件——需要什么类型就用什么类型

        //注意：
        //预设体对象加载需要实例化
        //其他资源类型加载直接使用

        #endregion

        #region 资源同步加载 普通方法

        //在一个工程中，Resources文件夹可以有多个 API加载的时
        //它会去这些同名的Resources文件夹中加载资源
        //打包的时候会把这些资源打包到一起


        //1.预设体对象 想要创建在场景上 记住实例化
        // 第一步:要去加载预设体的资源文件夹(本质上 就是加载 配置数据 在内存中)
        Object obj = Resources.Load("Cube");
        // 第二步:如果想要在场景上 创建预设体 一定是加载配置文件过后 然后实例化
        Instantiate(obj);

        // 第一步:要去加载预设体的资源文件夹(本质上 就是加载 配置数据 在内存中)
        Object obj2 = Resources.Load("Sphere");
        // 第二步:如果想要在场景上 创建预设体 一定是加载配置文件过后 然后实例化
        Instantiate(obj);



        //2.音效资源
        // 第一步:就是加载数据
        Object obj3 = Resources.Load("Music/BKMusic");
        // 第二步:使用数据 我们不需要实例化 音效切片 我们只需要 赋值到正确的脚本上即可
        AudioS.clip = obj3 as AudioClip;
        AudioS.Play();



        //3.文本资源
        //文本资源支持的格式
        //.txt
        //.json
        //.xml
        //.bytes
        //.csv
        //.html
        //.....
        TextAsset ta = Resources.Load("Txt/Text") as TextAsset;
        //文本内容
        print(ta.text);
        //字节数据组
        //print(ta.bytes);



        //4.图片资源
        tex = Resources.Load("Tex/TestJPG") as Texture;

        //5.其他资源 其他资源需要什么就用什么


        //6.资源同名怎么办
        //Resources.Load加载同名函数时 无法准确加载出你想要的内容

        //可以使用另外的API
        //6-1加载指定资源类型
        tex = Resources.Load("Tex/TestJPG", typeof(Texture)) as Texture;

        ta = Resources.Load("Tex/TestJPG", typeof(TextAsset)) as TextAsset;
        print(ta.text);

        //6-2加载指定名字下的所以资源
        Object[] objs = Resources.LoadAll("Tex/TestJPG");
        foreach (Object item in objs)
        {
            if (item is Texture)
            {

            }
            else if (item is TextAsset)
            {

            }
        }

        #endregion

        #region 资源同步加载 泛型方法

        TextAsset ta2 = Resources.Load<TextAsset>("Tex/TestJPG");
        print(ta2.text);

        tex = Resources.Load<Texture>("Tex/TestJPG");


        #endregion

        #region 总结

        //Resources动态加载资源的方法
        //让扩展性更强
        //相对拖曳来说 它更加一劳永逸 更加方便

        //注意：
        //预设体对象加载需要实例化!!!!!!!

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
