using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0003 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 向量

        //三维向量 —— Vector3       
        //具有两种几何意义
        // 1 位置 —— 代表一个点
        print(this.gameObject.transform.position);

        // 2 方向 —— 代表一个方向
        print(this.gameObject.transform.forward);
        print(this.gameObject.transform.right);

        Vector3 v1 = new Vector3(1, 2, 3);
        Vector2 v2 = new Vector2(6, 3);

        #endregion

        #region 两点确定一个向量

        // A和B此时 几何意义是两个点
        Vector3 A = new Vector3(1, 2, 3);
        Vector3 B = new Vector3(5, 2, 4);
        // 求向量
        Vector3 AB = B - A;
        Vector3 BA = A - B;

        #endregion

        #region 零向量和负向量

        print(Vector3.zero);

        print(Vector3.forward);
        print(-Vector3.forward);


        #endregion

        #region 向量的模长

        // Vector3中提供了获取向量模长的成员属性
        //magnitude
        print(AB.magnitude);
        Vector3 C = new Vector3(5, 6, 7);
        print(C.magnitude);

        // 求距离 为两点的距离 区别于向量的模长属性
        print(Vector3.Distance(A, B));


        #endregion

        #region 单位向量

        // Vector3提供了获取单位向量的成员属性
        //normalized
        print(AB.normalized);
        print(AB / AB.magnitude);


        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
