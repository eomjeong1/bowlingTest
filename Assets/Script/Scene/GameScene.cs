using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    void Start()
    {
        UIManger.GetInstance().OpenUI("ScoreBoardUI");
    }
}
