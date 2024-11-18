using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1002_execrcise : MonoBehaviour
{

    void Start()
    {
        #region 记秒器

        Coroutine c = StartCoroutine(MyCoroutine());

        #endregion

    }


    void Update()
    {
        #region 场景中创建10W个方块并且不卡顿

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //for (int i = 0; i < 100000; i++)
            //{
            //    GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //    obj.transform.position = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
            //}
            Coroutine c2 = StartCoroutine(CreateCube(100000));
        }


        #endregion
    }

    IEnumerator MyCoroutine()
    {
        int time = 0;

        while (true)
        {
            print(time + "秒");
            time++;
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator CreateCube(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
            if (i % 1000 == 0)
            {
                yield return null;
            }
        }
    }
}
