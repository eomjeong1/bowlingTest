using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    void Start()
    {
        UIManger.GetInstance().OpenUI("StartUI");
    }
}
