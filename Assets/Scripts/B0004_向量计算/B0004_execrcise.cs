using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0004_execrcise : MonoBehaviour
{
    public Transform target;

    public float zOffect;
    public float yOffect;

    // 相机相关只能写在lateUpdate
    private void LateUpdate()
    {
        this.transform.position = target.position + -target.forward * zOffect * 4 + target.up * yOffect * 7;
        this.transform.LookAt(target.position);
    }
}
