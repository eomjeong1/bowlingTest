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
        if (instance == null) // instance가 처음엔 null이고 다음 리턴에는 만들어져서 재실행되지 않는다.
        {
            GameObject go = new GameObject("@UIManager"); // @UIManager라는 오브젝트를 만들어주겠다.
            instance = go.AddComponent<UIManger>(); // TabUI라는 스크립트를 그 오브젝트에 AddComponent(추가)해주겠다.

            DontDestroyOnLoad(go); // 씬이 전환이 되더라도 파괴되지 않도록 하겠다.
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
