using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0007 : MonoBehaviour
{
    public GameObject Target;

    public float MoveSpeed;

    private Vector3 _oldStart;
    private Vector3 _oldTarget;
    private float _time = 0;

    private void Start()
    {
        _oldStart = this.transform.position;
        _oldTarget = Target.transform.position;
    }

    void Update()
    {
        #region 线性插值

        // result = start + (end - start) * t

        // 先快后慢
        //this.transform.position = Vector3.Lerp(this.transform.position, Target.transform.position, Time.deltaTime);

        // 匀速 t >= 1 到达目标
        if (_oldTarget != Target.transform.position)
        {
            _oldTarget = Target.transform.position;
            _oldStart = this.transform.position;
            _time = 0;
        }


        _time += Time.deltaTime;
        //this.transform.position = Vector3.Lerp(_oldStart, Target.transform.position, _time * MoveSpeed);


        #endregion

        #region 球形插值

        //this.transform.position = Vector3.Slerp(Target.transform.position + Vector3.forward * 10, Target.transform.position + Vector3.back * 10, _time);

        // 在Y轴方向上加一点向量，可以进行引导（模拟太阳东升西洛
        this.transform.position = Vector3.Slerp(Vector3.right * 10, Vector3.left * 10 + Vector3.up * 0.1f, _time * 0.1f);

        this.transform.LookAt(Target.transform.position);

        #endregion
    }
}
