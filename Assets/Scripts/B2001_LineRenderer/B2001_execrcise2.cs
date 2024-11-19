using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class B2001_execrcise2 : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public TMP_Text text;

    void Start()
    {
        #region 鼠标跟随

        //lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        //lineRenderer.loop = false;
        //lineRenderer.startWidth = 0.5f;
        //lineRenderer.endWidth = 0.5f;
        //lineRenderer.positionCount = 0;

        #endregion

    }

    private Vector3 nowPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = new GameObject();
            lineRenderer = obj.gameObject.AddComponent<LineRenderer>();
            lineRenderer.loop = false;
            lineRenderer.startWidth = 0.5f;
            lineRenderer.endWidth = 0.5f;
            lineRenderer.positionCount = 0;
        }

        if (Input.GetMouseButton(0))
        {
            lineRenderer.positionCount++;

            nowPos = Input.mousePosition;
            nowPos.z = 10.0f;

            lineRenderer.SetPosition(lineRenderer.positionCount - 1, Camera.main.ScreenToWorldPoint(nowPos));
        }
    }

}
