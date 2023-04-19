using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public Button StartBtn;

    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(GameStart);

    }
    void GameStart()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.GameScene);
    }
}
