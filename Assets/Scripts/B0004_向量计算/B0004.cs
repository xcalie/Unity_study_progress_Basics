using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0004 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 向量加法

        //this.gameObject.transform.position += new Vector3(3, 4, 6);
        //this.transform.Translate(new Vector3(3, 4, 6), Space.Self);

        #endregion

        #region 向量减法

        //this.gameObject.transform.position -= new Vector3(3, 4, 6);
        this.gameObject.transform.Translate(new Vector3(3, 4, 5), Space.Self);

        #endregion

        #region 向量乘除

        this.gameObject.transform.localScale *= 2;
        this.gameObject.transform.localScale /= 3;

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
