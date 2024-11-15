using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B0003_execrcise : MonoBehaviour
{
    public Transform A;
    public Transform B;

    // Start is called before the first frame update
    void Start()
    {
        print(Vector3.Distance(A.position, B.position));

        Vector3 AB = B.position - A.position;
        print(AB.magnitude);

        Vector3 BA = A.position - B.position;
        print(BA.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
