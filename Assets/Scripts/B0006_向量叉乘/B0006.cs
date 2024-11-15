using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0006 : MonoBehaviour
{
    public GameObject Target;


    // Start is called before the first frame update
    void Start()
    {
        #region 向量叉乘结果

        // 向量叉乘得到的是一个向量垂直于两个向量所处的平面
        //      A       B
        //      Xa      Xb
        //      Ya      Yb
        //      Za      Zb
        // 新向量得到的分别是是除了对应位置向量的矩阵式结果
        //例如 Xnew = Ya*Zb - Yb*Za

        // A x B = -(B x A)

        #endregion
    }

    private Vector3 _result;

    // Update is called once per frame
    void Update()
    {
        _result = Vector3.Cross(this.transform.forward, (Target.transform.position - this.transform.position).normalized);

        Debug.DrawRay(this.transform.position, this.transform.forward, Color.red);

        #region 叉乘计算结果

        print(_result);

        #endregion

        #region 叉乘的几何意义

        if (_result.y > 0)
        {
            Debug.Log("在右侧");
        }
        else
        {
            Debug.Log("在左侧");
        }

        #endregion
    }
}
