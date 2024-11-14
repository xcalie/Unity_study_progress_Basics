using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0002_execrcise : MonoBehaviour
{
    // Asin(x)

    // 向前移动速度
    public float VelocityZ = 1.0f;
    // 左右正弦移动速度
    public float VelocityX = 1.0f;
    // 左右距离钳制 A
    public float sinA = 1.0f;


    private float time = 0.0f;


    void Update()
    {
        // 面朝向移动
        this.transform.Translate(Vector3.forward * VelocityZ * Time.deltaTime);
        // 测朝向移动
        time += Time.deltaTime;
        this.transform.Translate(Vector3.right *  sinA * Time.deltaTime * Mathf.Sin(time));
    }
}
