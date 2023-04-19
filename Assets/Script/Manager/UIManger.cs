using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManger : MonoBehaviour
{
    #region SingletoneUI
    public static UIManger instance = null;
    public static UIManger GetInstance()
    {
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@UIManager"); // @UIManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<UIManger>(); // TabUI��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
        }
        return instance;
    }
    #endregion

    #region UI Control

    public void SetEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == false) 
        {
            GameObject go = new GameObject("@EventSystem"); 
            go.AddComponent<EventSystem>(); 
            go.AddComponent<StandaloneInputModule>(); 
        }
    }

    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false) 
        {           
            Object uiObj = Resources.Load("UI/" + uiName);
            GameObject go = (GameObject)Instantiate(uiObj); 
            uiList.Add(uiName, go);             
        }
        else
        {
            uiList[uiName].SetActive(true);
        }
    }


    public void CloseUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == true)
        {
            uiList[uiName].SetActive(false);
        }
    }


    public GameObject GetUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
            return uiList[uiName];

        return null; 
    }

    public void ClearList()
    {
        uiList.Clear();
    }
    #endregion  
}
