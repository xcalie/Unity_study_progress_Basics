using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2001_execrcise1 : MonoBehaviour
{
    public int numData = 10;
    public float radius = 1.0f;

    private List<Vector3> RoundData = new List<Vector3>(); 

    void Start()
    {
        #region 用lineRenderer绘制一个圆

        GameObject line = new GameObject();
        line.name = "Line";
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();

        lineRenderer.loop = true;

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        PreCollectData();

        lineRenderer.positionCount = numData;
        lineRenderer.SetPositions(RoundData.ToArray());


        lineRenderer.numCornerVertices = 100;
        lineRenderer.numCapVertices = 100;

        #endregion
    }

    private void PreCollectData()
    {
        
        float angle = 360.0f / numData;

        RoundData.Clear();
        for (int  i = 0; i < numData; i++)
        {
            RoundData.Add(this.transform.position + Quaternion.AngleAxis(angle * i, Vector3.up) * Vector3.forward * radius);
        }
    }

}
