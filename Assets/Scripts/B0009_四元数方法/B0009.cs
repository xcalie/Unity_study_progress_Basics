using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0009 : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform Target;

    private Quaternion start;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        #region 单位四元数

        print(Quaternion.identity);
        this.gameObject.transform.rotation = Quaternion.identity;
        //可以直接重置状态

        //Instantiate(this.gameObject.transform, Vector3.zero, Quaternion.identity);

        #endregion

        start = B.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        #region Slerp

        // lerp 和 Slerp 结果基本一致
        // Slerp效果更好
        //A.rotation = Quaternion.Slerp(A.rotation, Target.rotation, Time.deltaTime * 0.5f);

        time += Time.deltaTime;
        //B.rotation = Quaternion.Slerp(start, Target.rotation, time * 0.5f);

        #endregion

        #region 看向lookRotation

        A.rotation = Quaternion.LookRotation(Target.forward);

        B.rotation = Quaternion.LookRotation((Target.position - B.position).normalized);

        #endregion
    }
}
