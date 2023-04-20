using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int[] score = new int[9];
    public int frame = 0;

    bool isStrike;
    bool isSpare;
    int StrikeCheck;
    public int[] firstPinCount = new int[9];
    public int[] secondPinCount = new int[9];
    int thirdPinCount;

    public Text[] firstScoretxt;
    public Text[] secondScoretxt;
    public Text thirdScoretxt;
    public Text[] sumScoretxt;

    public Button InputBtn;
    public InputField InputField;

    public Player player = new Player("", 0, 0, 0, 0, 0, 0);

    public void Start()
    {
        OnclickBtn();
    }
    public void OnclickBtn()
    {
        InputBtn.onClick.AddListener(InputCheck);
    }

    public void InputCheck()
    {
        int i = frame;

        if (player.shootCount == 0)
        {
            Mathf.Clamp(firstPinCount[i], 0, 10);
            firstPinCount[i] = int.Parse(InputField.text);
            if (int.Parse(InputField.text) > 10)
            {
                Debug.Log("핀 개수를 초과합니다.");
            }
            if (firstPinCount[i] == 10)
            {
                isStrike = true;
                switch (StrikeCheck)
                {
                    case (0):
                        if (StrikeCheck == 0)
                        {
                            if (firstPinCount[i] == 10)
                                StrikeCheck = 1;
                        }
                        break;
                    case (1):
                        if (StrikeCheck == 1)
                        {
                            if (firstPinCount[i] == 10)
                                StrikeCheck = 2;
                        }
                        break;
                    case (2):
                        if (StrikeCheck == 2)
                        {
                            if (firstPinCount[i] == 10)
                                StrikeCheck = 3;
                        }
                        break;

                }

                Debug.Log("StrikeCheck :" + StrikeCheck);
                Debug.Log("프레임" + frame + "1번째 핀" + firstPinCount[i]);
            }
        }

        else if (player.shootCount == 1)
        {
            Mathf.Clamp(secondPinCount[i], 0, 10 - firstPinCount[i]);
            secondPinCount[i] = int.Parse(InputField.text);
            if (int.Parse(InputField.text) > 10 - firstPinCount[i])
            {
                Debug.Log("남은 핀 개수를 초과합니다.");
            }

            if (firstPinCount[i] + secondPinCount[i] == 10)
            {
                isSpare = true;
                Debug.Log("isSpare");
            }
            Debug.Log("프레임" + frame + "2번째 핀" + secondPinCount[i]);
        }
        else
        {
            thirdPinCount = int.Parse(InputField.text);
            Debug.Log(frame + thirdPinCount);
        }
        CalculateScore(i);
    }
    public void CalculateScore(int i)
    {
        int currentScore = score[i];
        Debug.Log("CalculateStart");

        if (player.shootCount == 0)
        {
            if (isStrike)
            {
                while (StrikeCheck == 0)
                {
                    if (StrikeCheck == 1)
                    {
                        continue;
                    }
                    if (StrikeCheck == 2)
                    {
                        continue;
                    }

                    else if (StrikeCheck == 3)
                    {
                        continue;
                    }
                }
            }
            else
            {
                if (player.shootCount == 2)
                {
                    score[i] = firstPinCount[i] + secondPinCount[i] + thirdPinCount;
                    Debug.Log(score[i]);
                    StrikeCheck = 0;
                }
                else
                {
                    if (StrikeCheck == 1)
                    {
                        score[i] = firstPinCount[i] + secondPinCount[i] + score[i];
                        score[i - 1] = firstPinCount[i] + secondPinCount[i] + score[i - 1];
                    }
                    if (StrikeCheck == 2)
                    {
                        score[i] = firstPinCount[i] + secondPinCount[i] + score[i];
                        score[i - 1] = firstPinCount[i] + secondPinCount[i] + score[i - 1];
                        score[i - 2] = firstPinCount[i - 1] + secondPinCount[i - 1] + score[i - 2];

                    }
                    else if (StrikeCheck == 3)
                    {
                        score[i] = firstPinCount[i] + secondPinCount[i] + score[i];
                        score[i - 1] = firstPinCount[i] + secondPinCount[i] + score[i - 1];
                        score[i - 2] = firstPinCount[i - 1] + secondPinCount[i - 1] + firstPinCount[i] + secondPinCount[i] + score[i - 2];
                        score[i - 3] = firstPinCount[i - 2] + secondPinCount[i - 2] + firstPinCount[i - 1] + secondPinCount[i - 1] + firstPinCount[i] + secondPinCount[i] + score[i - 3];

                    }
                    if(i > 0)
                    score[i] = firstPinCount[i] + secondPinCount[i] + score[i - 1];
                    else
                        score[i] = firstPinCount[i] + secondPinCount[i];

                    Debug.Log(score[i]);
                    StrikeCheck = 0;
                }
            }
        }
        if (player.shootCount == 1)
        {
            if (isSpare)
            {
                if (player.shootCount == 2)
                {
                    score[i] = firstPinCount[i] + secondPinCount[i] + thirdPinCount;
                    Debug.Log(score[i]);
                    isSpare = false;
                }
                else
                {
                    if (player.shootCount == 1)
                    {
                        while (player.shootCount == 0)
                        {
                            Debug.Log($"Skip : {frame}번째 프레임 점수");
                            if (player.shootCount == 0)
                            {
                                score[i] = firstPinCount[i] + secondPinCount[i] + firstPinCount[i + 1] + score[i - 1];
                                Debug.Log(score[i]);
                                isSpare = false;
                                break;
                            }
                        }
                    }
/*                    else if (player.shootCount == 0)
                    {
                        score[i] = firstPinCount[i] + secondPinCount[i] + firstPinCount[i + 1] + score[i - 1];
                        Debug.Log(score[i]);
                        isSpare = false;
                    }*/

                }
            }
            else
            {
                if (i > 0)
                    score[i] = firstPinCount[i] + secondPinCount[i] + score[i - 1];
                else
                    score[i] = firstPinCount[i] + secondPinCount[i];

                Debug.Log(score[i]);
            }
        }

        PrintScore(i);
    }
    public void PrintScore(int i)
    {
        Debug.Log("PrintStart");
        if (player.shootCount == 0)
        {
            if (isStrike)
            {
                firstScoretxt[i].text = "X";
                secondScoretxt[i].text = "";
                if (StrikeCheck > 0)
                {
                    sumScoretxt[i].text = "";
                    Debug.Log("Strike : " + score[i]);
                }
                else
                {                   
                    sumScoretxt[i].text = $"{score[i]}";
                    Debug.Log("Strike : " + score[i]);
                }
            }
            else if (firstPinCount[i] == 0)
            {
                firstScoretxt[i].text = "-";
            }
            else
            {
                firstScoretxt[i].text = $"{firstPinCount[i]}";
                Debug.Log(score[i]);
            }
        }
        if (player.shootCount == 1)
        {
            if (player.spareCount != 2)
            {
                if (isSpare)
                {
                    secondScoretxt[i].text = "/";
                    sumScoretxt[i].text = "";
                    Debug.Log("Spare : " + score[i]);
                }
                else if (secondPinCount[i] == 0)
                {
                    secondScoretxt[i].text = "-";
                    sumScoretxt[i].text = $"{score[i]}";
                }
                else
                {
                    secondScoretxt[i].text = $"{secondPinCount[i]}";
                    sumScoretxt[i].text = $"{score[i]}";
                    Debug.Log(score[i]);
                }
            }
            else
            {
                if (secondPinCount[i] == 0)
                {
                    secondScoretxt[i].text = "-";
                    sumScoretxt[i].text = "";
                }
                else
                {
                    secondScoretxt[i].text = $"{secondPinCount[i]}";
                }
            }

        }

        if (player.shootCount == 2)
        {
            if (thirdPinCount == 0)
            {
                thirdScoretxt.text = "-";
            }
            else
            {
                thirdScoretxt.text = thirdPinCount.ToString();
            }
            sumScoretxt[i].text = $"{score[i]}";
        }
        player.JudgeShootCount(this, i);

    }
}