using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class B0007_camera : MonoBehaviour
{
    public Transform target;

    public float zOffect;
    public float yOffect;

    private Vector3 oldTarget;
    private Vector3 oldStart;
    private float time = 0;

    // 相机相关只能写在lateUpdate
    private void LateUpdate()
    {
        if (oldTarget != target.position + -target.forward * zOffect * 4 + target.up * yOffect * 7)
        {
            oldTarget = target.position + -target.forward * zOffect * 4 + target.up * yOffect * 7;
            oldStart = this.transform.position;
            time = 0;
        }

        time += Time.deltaTime;
        this.transform.position = Vector3.Lerp(oldStart, oldTarget, time);

        this.transform.LookAt(target.position);
    }
}

abstract class Person
{
    public virtual void play()
    {
        Debug.Log("s");
    }

}

class Student : Person
{
    public override void play()
    {
        base.play();
    }
}

