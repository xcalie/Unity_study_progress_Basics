using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0001 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region math mathf

        //Math是C#中已经封装好的数学计算类 —— 位于System命名空间中
        //Mathf是unity中已经封装好的数学计算类 —— 位于unityEngine中

        //用于数学辅助计算

        #endregion

        #region 区别

        //Mathf 和 Math 中的方法几乎一致
        //Math 是 C#自带的工具类 主要提供一些数学计算相关的计算方法
        //Math 是unity专门封装的 除了提供数学计算方法 还有一部分 游戏相关方法

        //直接用Mathf

        #endregion

        #region Mathf中的方法 一般一次计算

        // PI
        print(Mathf.PI);

        // 取绝对值Abs
        print(Mathf.Abs(-10));
        print(Mathf.Abs(10));


        float f = 1.3f;
        //取整
        //向上
        print(Mathf.CeilToInt(f));
        //向下
        print(Mathf.FloorToInt(f));

        //钳制函数 Clamp
        //第一个参数的范围始终在两个极值范围内，超过则赋值极值
        print(Mathf.Clamp(10, 11, 20));
        print(Mathf.Clamp(22, 11, 20));
        print(Mathf.Clamp(15, 11, 20));

        //最大值 Max
        print(Mathf.Max(1, 3, 9, 4, 3, 4));

        //最小值 Min
        print(Mathf.Min(2, 3, 4, 5));

        // n次幂
        // 2的3次方
        print(Mathf.Pow(2, 3));

        // 四舍五入
        print(Mathf.RoundToInt(f));

        // 返回平方根
        print(Mathf.Sqrt(16));

        // 判断某个数是否是二的n次方
        print(Mathf.IsPowerOfTwo(16));
        print(Mathf.IsPowerOfTwo(81));

        // 判断正负数
        // 0 和 正数 为 1
        // 负数 为 -1
        print(Mathf.Sign(0));
        print(Mathf.Sign(-11));
        print(Mathf.Sign(12));


        #endregion

    }

    // 初始值
    float start = 0;
    // 结束值
    float result = 0;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        #region Mathf中的常用方法 一般不停计算

        // 插值运算 Lerp

        // Lerp函数公式
        // result = Mathf.Lerp(start, end, t);

        //start = Mathf.Lerp(start, 10, 0.1f);

        // t 为插值系数 取值范围 0~1
        // result = start + (end - start)*t

        // 每帧改变start的值————变化速度先快后慢 位置无限接近 得不到end的位置
        start = Mathf.Clamp(start, 10, Time.deltaTime);

        // 每帧改变t的值————变化匀速，位置每帧接近，当t>=1时得到结果
        time += Time.deltaTime;
        result = Mathf.Clamp(start, 10, time);


        #endregion
    }
}
