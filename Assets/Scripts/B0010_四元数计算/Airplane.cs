using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public enum E_FireType
{
    //单发
    One,
    //双发
    Two,
    //扇形
    Three,
    //环形
    Round
}



public class Airplane : MonoBehaviour
{
    private GameObject bullet;

    public float TwoBulletWides = 1.0f;
    public int NumRound = 4;

    private E_FireType nowType = E_FireType.One;

    void Start()
    {
        //放在其他地方再次加载，不会浪费内存，但是会浪费性能
        bullet = Resources.Load<GameObject>("Bullet");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            nowType = E_FireType.One;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nowType = E_FireType.Two;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            nowType = E_FireType.Three;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            nowType = E_FireType.Round;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        switch (nowType)
        {
            case E_FireType.One:
                Instantiate(bullet, this.transform.position, this.transform.rotation);
                break;
            case E_FireType.Two:
                Instantiate(bullet, this.transform.position - this.transform.right * TwoBulletWides, this.transform.rotation);
                Instantiate(bullet, this.transform.position + this.transform.right * TwoBulletWides, this.transform.rotation);
                break;
            case E_FireType.Three:
                //正面发射
                Instantiate(bullet, this.transform.position, this.transform.rotation);
                //朝自己左侧20度发射
                Instantiate(bullet, this.transform.position, this.transform.rotation * Quaternion.AngleAxis(20, this.transform.up));
                //朝自己右侧20度发射
                Instantiate(bullet, this.transform.position, this.transform.rotation * Quaternion.AngleAxis(-20, this.transform.up));
                break;
            case E_FireType.Round:
                float angle = 360 / NumRound;
                for (int i = 0; i < NumRound; i++)
                {
                    Instantiate(bullet, this.transform.position, this.transform.rotation * Quaternion.AngleAxis(i * angle, this.transform.up));
                }
                break;
        }
    }
}
