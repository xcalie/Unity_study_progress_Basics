using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B1008 : MonoBehaviour
{

    void Start()
    {
        #region ����ͬ���л�

        //ͬ���л���ֱ�ӽ������ϵĶ���ȫ��ɾ������һ������³����Ķ���
        //���ܻᵼ�¿���
        SceneManager.LoadScene("B1008Test");

        #endregion

        #region �����첽�л�

        //�����첽���غ���Դ�첽���ؼ�����ͬ

        //1ͨ��ʱ��ص����� �첽����
        AsyncOperation ao = SceneManager.LoadSceneAsync("B1008Test");
        //�������첽������֮�� ���Զ����øú��� ���ϣ���ڼ�����֮����һЩ����
        //�Ϳ����ڸĺ�����д�����߼�
        ao.completed += (a) =>
        {
            print("���ؽ���");
        };

        ao.completed += LoadOver;



        //2ͨ��Э���첽����
        //��Ҫע����� ���س�����ѵ�ǰ������ û���ر���Ķ��� ��ɾ����
        //���� Э���в����߼� ������ִ�в��˵�
        //���˼·
        //�ô��������صĽŲ������Ķ��� ���л�ʱ��ɾ��

        //������������ɾ��
        DontDestroyOnLoad(this.gameObject);

        StartCoroutine(LoadSence("B1008Test"));


        #endregion
    }

    private void LoadOver(AsyncOperation ao)
    {
        print("LoadOver");
    }

    IEnumerator LoadSence(string name)
    {
        //��һ��
        //�첽���س���
        AsyncOperation ao = SceneManager.LoadSceneAsync("B1008Test");
        //Unity�ڲ���Э�̴����� �ᴦ���Ӧ�������� �ȴ��첽����
        //������֮�� �Ż�ִ����һ����
        print("�첽���ع����д�ӡ����Ϣ");
        //Э�̵ĺô� �����ڼ��ع����д��������߼�
        yield return ao;
        //�ڶ���
        print("�첽���ؽ������ӡ����Ϣ");
    }
}
