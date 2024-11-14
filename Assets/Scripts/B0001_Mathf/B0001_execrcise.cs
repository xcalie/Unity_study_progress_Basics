using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class B0001_execrcise : MonoBehaviour
{
    public GameObject followed;
    public float moveSpeed;

    //private Vector3 pos;

    private Vector3 posOld;

    private Vector3 followedEnd;
    private Vector3 posEnd;
    private float time;


    private void Start()
    {
        posOld = transform.position;
    }



    void Update()
    {
        //第一种先快后慢 但不能达到
        //pos = this.transform.position;

        //pos.x = Mathf.Lerp(pos.x, followed.transform.position.x, Time.deltaTime * moveSpeed);
        //pos.y = Mathf.Lerp(pos.y, followed.transform.position.y, Time.deltaTime * moveSpeed);
        //pos.z = Mathf.Lerp(pos.z, followed.transform.position.z, Time.deltaTime * moveSpeed);

        //this.transform.position = pos;



        // 第二种匀速运动 可以达到
        if (followedEnd != followed.transform.position)
        {
            followedEnd = followed.transform.position;
            posOld = this.transform.position;
            time = 0;
        }

        time += Time.deltaTime * moveSpeed;
        posEnd.x = Mathf.Lerp(posOld.x, followedEnd.x, time);
        posEnd.y = Mathf.Lerp(posOld.y, followedEnd.y, time);
        posEnd.z = Mathf.Lerp(posOld.z, followedEnd.z, time);

        this.transform.position = posEnd;
    }
}
