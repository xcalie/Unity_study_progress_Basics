using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0002 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 角度&弧度

        //弧度转角度 Rad to Deg
        float rad = 1;
        float anger = rad * Mathf.Rad2Deg;
        print(anger);

        //角度转弧度 
        anger = 1;
        rad = anger * Mathf.Deg2Rad;
        print(rad);


        #endregion

        #region 三角函数

        //  Mathf的三角函数传入弧度值
        print(Mathf.Sin(30 * Mathf.Deg2Rad));
        print(Mathf.Cos(60 * Mathf.Deg2Rad));


        #endregion

        #region 反三角函数

        // 反三角函数得到的是 正弦和余弦 对应的弧度
        rad = Mathf.Asin(0.5f);
        print(rad * Mathf.Rad2Deg);

        rad = Mathf.Acos(0.5f);
        print(rad * Mathf.Rad2Deg);

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
