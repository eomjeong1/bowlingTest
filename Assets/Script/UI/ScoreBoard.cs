using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text HdcpScoretxt;
    public Text MaxPossibletxt;
    public InputField InputPin;
    public Button InputBtn;
    public int[] frameFirstPin;
    public int[] frameSecondPin;

    public int[] btnArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    public void Start()
    {
        InputBtn.onClick.AddListener(CheckPin);
    }
    public void CheckPin()
    {
        GameManager.GetInstance().firstpinCount = int.Parse(InputPin.text);
        Debug.Log(GameManager.GetInstance().firstpinCount);
        RecordPinCount();
    }

    public void InstantiatePin()
    {
        for (int i = 0; i < btnArray.Length; i++)
        { 
            
        }
    }
    public void RecordPinCount()
    {
        for (int i = 0; i < 10; i++)
        { 
          
        }
    }
}
