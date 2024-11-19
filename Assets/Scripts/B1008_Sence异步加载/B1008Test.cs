using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1008Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneMgr.Instance.LoadScene("B1008", () =>
        {
            Debug.Log("B1008场景加载完成");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
