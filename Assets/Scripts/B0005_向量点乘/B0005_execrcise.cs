using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0005_execrcise : MonoBehaviour
{
    public GameObject Target;
    public float TargetAngle;



    private float _distence = 0;
    private float _angle = 0;

    void Update()
    {
        //_distence = (Target.transform.position - this.transform.position).magnitude;
        _distence = Vector3.Distance(Target.transform.position, this.transform.position);

        //_angle = Mathf.Acos(Vector3.Dot(this.transform.forward, (Target.transform.position - this.transform.position).normalized));
        _angle = Vector3.Angle(this.transform.forward, (Target.transform.position - this.transform.position).normalized);

        //Debug.Log("距离" + _distence);
        //Debug.Log("角度" + _angle);

        if (_distence <= 5.0f && _angle <= TargetAngle / 2.0f)
        {
            Debug.Log("发现byd");
        }
        
    }
}
