using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class B0005 : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        #region 调试画线

        //画线段
        //两个参数分别是  起点 终点
        //Debug.DrawLine(this.transform.position, target.transform.position, Color.red);

        //画射线
        //两个参数分别是  起点 方向
        //Debug.DrawRay(this.transform.position, this.transform.forward, Color.green);

        #endregion

        #region 点乘判断方位

        //Vector3提供了计算点乘的方法
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.red);
        Debug.DrawRay(this.transform.position, target.transform.position - this.transform.position, Color.green);

        //得到两个向量点乘的结果
        // 向量 a 点乘向量 AB 的结果
        float result = Vector3.Dot(this.transform.forward, target.transform.position - this.transform.position);
        if (result >= 0)
        {
            //Debug.Log("目标在我前方");
        }
        else
        {
            //Debug.Log("目标在我后方");
        }


        #endregion

        #region 利用点乘算出夹角

        //步骤
        // 用单位向量算出点乘结果
        float dotResult = Vector3.Dot(this.transform.forward, (target.transform.position - this.transform.position).normalized);
        // 用反三角函数得出的角度
        Debug.Log("角度：" + Mathf.Acos(dotResult) * Mathf.Rad2Deg);

        // Vector3中有得出角度的方法
        Debug.Log("角度：" + Vector3.Angle(this.transform.forward, (target.transform.position - this.transform.position).normalized));

        #endregion
    }
}
