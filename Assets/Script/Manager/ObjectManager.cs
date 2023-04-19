using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    #region SingletoneUI
    public static ObjectManager instance = null;
    public static ObjectManager GetInstance()
    {
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@ObjectManager"); // @ObjectManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<ObjectManager>(); // ObjectManager��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
        }
        return instance;
    }
    #endregion

    public GameObject CreateBtn(string btnName)
    {
        Object btnObj = Resources.Load("UI/" + btnName);
        GameObject btn = (GameObject)Instantiate(btnObj);
        return btn;
    }
    public GameObject CreatePin(string pinName)
    {
        Object pinObj = Resources.Load("UI/" + pinName);
        GameObject pin = (GameObject)Instantiate(pinObj);
        return pin;
    }
}
