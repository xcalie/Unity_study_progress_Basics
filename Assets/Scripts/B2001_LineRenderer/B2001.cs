using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2001 : MonoBehaviour
{
    public Material m;

    void Start()
    {
        #region LineRenderer是什么

        //LineRenderer是Unity中提供的一个用于绘制线条的组件
        //使用它可以用我们可以在场景中绘制线段
        //一般还可用于
        //1绘制攻击范围
        //2武器红外线
        //3辅助功能
        //4其他画线功能

        #endregion

        #region LineRenderer的参数

        #endregion

        #region LineRenderer的代码

        GameObject line = new GameObject();
        line.name = "Line";
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();

        //首尾相连
        lineRenderer.loop = true;

        //开始结束宽度
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        //设置材质
        m = Resources.Load<Material>("M");
        lineRenderer.material = m;

        //设置点
        //设置点一定要先设置点的数量
        lineRenderer.positionCount = 4;
        //接着设置点的位置
        //没有设置点的位置的话，未设置点的位置默认为Vector3.zero
        lineRenderer.SetPositions(new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
        });
        lineRenderer.SetPosition(3, new Vector3(1, 0, 0));

        //是否使用世界坐标
        //决定了 是否随对象移动而移动
        lineRenderer.useWorldSpace = true;

        //设置是否受光照影响 会对其进行着色器计算
        lineRenderer.generateLightingData = true;

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
