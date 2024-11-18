using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0010 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 四元数乘

        //相乘实现旋转，z这里是以自己的y轴旋转30度
        Quaternion q = Quaternion.AngleAxis(20, Vector3.up);
        this.transform.rotation *= q;
        //四元数是旋转量

        #endregion

    }

    // Update is called once per frame
    void Update()
    {

        #region 四元数乘向量

        Quaternion q1 = Quaternion.AngleAxis(30, Vector3.up);

        //rotation本质是一个方向向量
        //向量相乘得到的是一个旋转后的向量
        Vector3 v = Vector3.right;
        Debug.DrawRay(Vector3.zero, v);

        v = q1 * v;
        Debug.DrawRay(Vector3.zero, v);

        v = q1 * v;
        Debug.DrawRay(Vector3.zero, v);

        #endregion
    }
}
