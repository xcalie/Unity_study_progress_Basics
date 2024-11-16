using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0009_execrcise : MonoBehaviour
{
    public GameObject Target;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.rotation = Quaternion.LookRotation((Target.transform.position - this.transform.position).normalized);
    }
}
