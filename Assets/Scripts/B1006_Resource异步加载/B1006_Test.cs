using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1006_Test : MonoBehaviour
{
    public Texture tex;


    void Start()
    {
        ResourcesMgr.Instance.LoadRes<Texture>("Tex/TestJPG", (obj) =>
        {
            tex = obj;
        });


        //异步加载 与上面的方式等价
        ResourceRequest rq = Resources.LoadAsync<Texture>("Tex/TestJPG");
        rq.completed += (a) =>
        {
            tex = (a as ResourceRequest).asset as Texture;
        };
    }

    private void OnGUI()
    {
        if (tex != null)
        {
            GUI.DrawTexture(new Rect(0, 0, 200, 100), tex);
        }
    }
}
