using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //目标对象
    public Transform target;
    //相对头顶的偏移位置
    public float headOffetH = 1;
    //倾斜角度
    public float angle = 45;
    //默认的摄像机离观测点的距离
    public float dis = 5;

    //鼠标缩放速度
    public float roundSpeed = 1;
    //相机缩放距离限制
    public float minDis = 3;
    public float maxDis = 10;

    //相机旋转速度
    public float RoundSpeed = 1;

    private void Start()
    {

    }

    //当前摄像机应该在的位置
    private Vector3 nowPos;
    private Vector3 nowDir;

    private void LateUpdate()
    {
        //实现鼠标中键改动
        dis += -Input.GetAxis("Mouse ScrollWheel") * roundSpeed;
        dis = Mathf.Clamp(dis, minDis, maxDis);

        //头顶偏移位置
        nowPos = target.position + target.up * headOffetH;
        //往后方偏移位置
        nowDir = Quaternion.AngleAxis(angle, target.right) * -target.forward;
        nowPos = nowPos + nowDir * dis;

        this.transform.position = nowPos;
        Debug.DrawLine(this.transform.position, target.position + target.up * headOffetH);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(-nowDir), Time.deltaTime * RoundSpeed);
    }
}
