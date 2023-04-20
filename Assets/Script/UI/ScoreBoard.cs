using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreBoard : MonoBehaviour
{ 
    public int[] score = new int[10];           // 점수 배열
    public int frame = 0;                       // 현재 프레임
    
    bool isStrike;                              // 스트라이크 확인
    bool isSpare;                               // 스페어 확인
    int StrikeCheck;                            // 연속 스트라이크 확인(더블, 트리플(터키))
    public int[] firstPinCount = new int[10];   // 첫번째 투구에서 넘어진 핀의 개수 배열
    public int[] secondPinCount = new int[10];  // 두번째 투구에서 넘어진 핀의 개수 배열
    int thirdPinCount;                          // 10번째 프레임 보너스 투구에서 넘어진 핀의 개수
    int[] frameScore;                           // 현재 프레임 점수

    public Text[] firstScoretxt;                // 첫번째 투구로 얻은 점수 텍스트 배열
    public Text[] secondScoretxt;               // 두번째 투구로 얻은 점수 텍스트 배열
    public Text thirdScoretxt;                  // 10번째 프레임 보너스 투구로 얻은 점수 텍스트
    public Text[] sumScoretxt;                  // 프레임 당 합산 점수 텍스트 배열

    public Button InputBtn;                     // 넘어뜨린 핀 개수 입력 버튼
    public InputField InputField;               // 넘어뜨린 핀 개수 입력 란

    public Player player = new Player("", 0, 0, 0, 0, 0, 0); // 플레이어 정보

    public void Start()
    {
        OnclickBtn();
    }

    /// <summary>
    /// 버튼 온클릭 기능 추가
    /// </summary>
    public void OnclickBtn()
    {
        InputBtn.onClick.AddListener(InputCheck);
    }

    /// <summary>
    /// 입력된 텍스트를 점수로 변환
    /// </summary>
    public void InputCheck()
    {
        int i = frame;

        if (player.shootCount == 0) // 프레임 별 첫번째 투구 일 때
        {
            firstPinCount[i] = int.Parse(InputField.text);
            if (int.Parse(InputField.text) > 10) // 입력된 핀의 개수가 10개 이상이면 리턴 
            {
                Debug.Log("핀 개수를 초과합니다.");
                return;
            }
            if (firstPinCount[i] == 10)  // 입력된 핀의 개수가 10개면 스트라이크
            {
                isStrike = true;
                switch (StrikeCheck)  // 연속 스트라이크 확인
                {
                    case (0):
                        if (StrikeCheck == 0) // 스트라이크
                        {
                            if (firstPinCount[i] == 10)
                                StrikeCheck = 1;
                        }
                        break;
                    case (1):
                        if (StrikeCheck == 1) // 더블
                        {
                            if (firstPinCount[i] == 10)
                                StrikeCheck = 2;
                        }
                        break;
                    case (2):
                        if (StrikeCheck == 2) // 트리플(터키)
                        {
                            if (firstPinCount[i] == 10)
                                StrikeCheck = 3;
                        }
                        break;

                }
            }
            else // 입력된 핀의 개수가 10개 미만이면
            {
                isStrike = false;
                Debug.Log("isStrike = false");
            }
                Debug.Log("프레임" + frame + "1번째 핀" + firstPinCount[i]);
        }

        else if (player.shootCount == 1) // 프레임 별 두번째 투구
        {
            secondPinCount[i] = int.Parse(InputField.text);
            if (int.Parse(InputField.text) > 10 - firstPinCount[i]) 
                // 두번째 핀의 개수가 첫번째 핀의 개수와 더했을 때 10이상이면 리턴
            {
                Debug.Log("남은 핀 개수를 초과합니다.");
            }

            if (firstPinCount[i] + secondPinCount[i] == 10) 
                // 첫번째 핀과 두번째 핀의 합이 10이면 스페어
            {
                isSpare = true;
                Debug.Log("isSpare");
            }
            else
            {
                isSpare = false;
                Debug.Log("isSpare = false");
            }
 


            Debug.Log("프레임" + frame + "2번째 핀" + secondPinCount[i]);
        }
        else // 3번째 투구, 10프레임의 보너스 투구일 때
        {
            thirdPinCount = int.Parse(InputField.text);
            Debug.Log(frame + thirdPinCount);
        }
        CalculateScore(i); // 점수 계산함수로
    }

    /// <summary>
    /// 점수를 계산하는 함수
    /// </summary>
    /// <param name="i">현재 프레임</param>
    public void CalculateScore(int i)
    {

        Debug.Log("CalculateStart");

        if (player.shootCount == 0) // 첫번째 투구일 때
        {
            if (isStrike) // 스트라이크 조건일 때
            {
                if (StrikeCheck == 1) // 스트라이크 일때
                {
                    if (i > 0)
                        score[i] = score[i - 1] + firstPinCount[i] + secondPinCount[i] + firstPinCount[i+1] + secondPinCount[i+1]; // score[i-1] : 전 프레임까지 얻은 점수
                    else
                        score[i] = firstPinCount[i] + secondPinCount[i];

                    Debug.Log(score[i]);
                }
                if (StrikeCheck == 2) // 더블일 때
                {
                    score[i] = score[i - 1] + firstPinCount[i] + secondPinCount[i] + firstPinCount[i + 1] + secondPinCount[i + 1] + firstPinCount[i + 2] + secondPinCount[i + 2];

                    Debug.Log(score[i]);
                    
                }
                else if (StrikeCheck == 3) // 트리플일 때
                {
                    score[i] = score[i - 1] + 30;

                    Debug.Log(score[i]);
                   
                }
            }
            else // 스트라이크 조건이지만 마지막 보너스 투구일 때
            {
                if (player.shootCount == 2)
                {
                    score[i] = firstPinCount[i] + secondPinCount[i] + thirdPinCount;
                    Debug.Log(score[i]);
                    StrikeCheck = 0;
                }
                Debug.Log(score[i]);
                StrikeCheck = 0;


            }
            Debug.Log("StrikeCheck :" + StrikeCheck);
        }
        if (player.shootCount == 1)
        {
            if (isSpare)
            {
                if (player.shootCount == 2)
                {
                    score[i] = score[i - 1] + firstPinCount[i] + secondPinCount[i] + thirdPinCount;
                    Debug.Log(score[i]);
                }
                else
                {
                    if(i > 0)
                    score[i] = score[i-1] + firstPinCount[i] + secondPinCount[i] + firstPinCount[i + 1];
                    else
                        score[i] = firstPinCount[i] + secondPinCount[i] + firstPinCount[i + 1];
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