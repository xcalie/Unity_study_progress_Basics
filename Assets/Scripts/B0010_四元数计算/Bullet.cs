using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MoveSpeed = 10;

    private void Start()
    {
        Destroy(this.gameObject, 5);        
    }


    void Update()
    {
        this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
    }
}
