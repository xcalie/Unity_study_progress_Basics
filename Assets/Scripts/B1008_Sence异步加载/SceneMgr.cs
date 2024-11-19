using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    private static SceneMgr instance = new SceneMgr();

    public static SceneMgr Instance => instance;


    private SceneMgr()
    {

    }


    public void LoadScene(string name, UnityAction callback)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        ao.completed += (a) =>
        {
            //通过lambda表达式调用回调函数
            callback();
        };
    }
}
