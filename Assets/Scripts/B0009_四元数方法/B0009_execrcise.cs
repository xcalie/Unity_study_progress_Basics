using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0009_execrcise : MonoBehaviour
{
    public GameObject Target;

    private Quaternion TargetQ;
    private Vector3 _oldTargetVr;
    private Quaternion _oldStart;
    private float time = 0;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.rotation = Quaternion.LookRotation((Target.transform.position - this.transform.position).normalized);
        
        //旋转结果朝向
        //TargetQ = Quaternion.LookRotation((Target.transform.position - this.transform.position).normalized);
        
        //先快后慢
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, TargetG, Time.deltaTime);
        
        //匀速
        if (_oldTargetVr != Target.transform.position)
        {
            //TargetR = (Target.transform.position - this.transform.position).normalized;
            TargetQ = Quaternion.LookRotation((Target.transform.position - this.transform.position).normalized);
            _oldStart = this.transform.rotation;
            time = 0;
        }

        time += Time.deltaTime;
        this.transform.rotation = Quaternion.Slerp(_oldStart, TargetQ, time);
    }
}
