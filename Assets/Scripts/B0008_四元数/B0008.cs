using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0008 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 四元数

        //四元数 Q = [cos(β/2), sin(β/2)x, sin(β/2)y, sin(β/2)z]
        Quaternion q = new Quaternion(Mathf.Sin(30 * Mathf.Deg2Rad) * 1, 0, 0, Mathf.Cos(30 * Mathf.Deg2Rad));

        //创建立方体
        //GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //obj.transform.rotation = q;

        Quaternion q2 = Quaternion.AngleAxis(60, Vector3.right);
        //obj.transform.rotation = q2;

        #endregion

        #region 四元数欧拉角转换

        //欧拉角 转 四元数
        Quaternion q3 = Quaternion.Euler(60, 0, 0);
        //欧拉角 转 四元数
        Debug.Log(q3.eulerAngles);

        #endregion

        
    }

    // Update is called once per frame
    Vector3 e;
    void Update()
    {
        #region 四元数弥补的欧拉角缺点

        // 同一旋转角度 四元数 永远是 -180度 ~ 180度

        // 万向节死锁 通过四元数避免万向节死锁
        //this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.forward);
        this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.up);

        //e = this.transform.rotation.eulerAngles;
        //e += Vector3.forward;
        //e += Vector3.up;
        //this.transform.rotation = Quaternion.Euler(e);


        #endregion
    }
}
