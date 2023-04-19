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
        if (instance == null) // instance가 처음엔 null이고 다음 리턴에는 만들어져서 재실행되지 않는다.
        {
            GameObject go = new GameObject("@ObjectManager"); // @ObjectManager라는 오브젝트를 만들어주겠다.
            instance = go.AddComponent<ObjectManager>(); // ObjectManager라는 스크립트를 그 오브젝트에 AddComponent(추가)해주겠다.

            DontDestroyOnLoad(go); // 씬이 전환이 되더라도 파괴되지 않도록 하겠다.
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
