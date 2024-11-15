using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class B0006_execrcise : MonoBehaviour
{
    public GameObject Target;


    private float _angle;
    private float _distance;
    private Vector3 _cross;

    private Vector3 _two;

    void Update()
    {
        _two = (Target.transform.position - this.transform.position).normalized;


        //_angle = Mathf.Acos(Vector3.Dot(_two, this.transform.forward));
        _angle = Vector3.Angle(_two, this.transform.forward);

        //_distance = (Target.transform.position - this.transform.position).magnitude;
        _distance = Vector3.Distance(Target.transform.position, this.transform.position);
        _cross = Vector3.Cross(_two, this.transform.forward);

        Debug.DrawRay(this.transform.position, this.transform.forward, Color.yellow);

        #region 判断方位

        if (_cross.y > 0.0f && _angle < 90.0f)
        {
            //Debug.Log("在左前方");
        }
        else if (_cross.y > 0.0f && _angle > 90.0f)
        {
            //Debug.Log("在左后方");
        }
        else if (_cross.y < 0.0f && _angle < 90.0f)
        {
            //Debug.Log("在右前方");
        }
        else if (_cross.y < 0.0f && _angle > 90.0f)
        {
            //Debug.Log("在右后方");
        }

        #endregion

        #region 在左前方20度 和 右前方30度 发现发现敌人

        Debug.Log("_angle" +  _angle);

        if (((_cross.y >= 0.0f && _angle < 20.0f) || ((_cross.y <= 0) && (_angle < 30.0f))) && _distance <= 5)
        {
            Debug.Log("发现byd");
        }

        #endregion
    }
}
