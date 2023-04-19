using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frame : MonoBehaviour
{
    public Text FrameNumber; 
    public Text firstScore;
    public Text secondScore;
    public Text SumScore;

    public void Start()
    {
        FrameNumber.text = GameManager.GetInstance().FrameNum.ToString();
        RecordScore();
    }
    public void RecordScore()
    {
        if (GameManager.GetInstance().firstShoot == true)
        {
            if (GameManager.GetInstance().firstpinCount == 10)
            {
                firstScore.text = "X";
                secondScore.text = "";
                SumScore.text = "";
            }
            else if (GameManager.GetInstance().firstpinCount == 0)
            {
                firstScore.text = "-";
            }
            else
            {
                firstScore.text = GameManager.GetInstance().firstpinCount.ToString();
            }
        }
        if (GameManager.GetInstance().lastShoot == true)
        {
            if (GameManager.GetInstance().lastpinCount + GameManager.GetInstance().firstpinCount == 10)
            {
                secondScore.text = "/";
            }
            else
            {
                secondScore.text = GameManager.GetInstance().lastpinCount.ToString();
            }
        }


        
        SumScore.text = (GameManager.GetInstance().firstpinCount + GameManager.GetInstance().lastpinCount).ToString();
    }
}
