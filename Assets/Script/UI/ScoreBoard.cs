using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int[] score = new int[11];
    int frame = 1;

    bool isStrike = false;
    bool isSpare = false;
    bool isfirstShoot = true;
    bool isSecondShoot = false;
    bool isThirdShoot = false;
    int[] firstPinCount = new int[11];
    int[] secondPinCount = new int[11];
    int thirdPinCount;

    public Text[] firstScoretxt;
    public Text[] secondScoretxt;
    public Text thirdScoretxt;
    public Text[] sumScoretxt;

    public Button InputBtn;
    public InputField InputField;
    public void Start()
    {
        score[0] = 0;
        firstPinCount[0] = 0;
        secondPinCount[0] = 0;
        OnclickBtn();
    }
    public void OnclickBtn()
    {
        InputBtn.onClick.AddListener(ShootCheck);
    }
    public void ShootCheck()
    {
        if (isfirstShoot == true)
            isSecondShoot = false;
        if (isStrike)
            isfirstShoot = true;

        InputCheck();
    }
    public void InputCheck()
    {
        int i = frame;
        if (isfirstShoot)
        {
            Mathf.Clamp(firstPinCount[i], 0, 10);
            firstPinCount[i] = int.Parse(InputField.text);
            if (int.Parse(InputField.text) > 10 - firstPinCount[i])
            {
                Debug.Log("핀 개수를 초과합니다.");
                ShootCheck();
            }
            if (firstPinCount[i] == 10)
                isStrike= true;
            
            Debug.Log(frame + firstPinCount[i]);
        }

        if (isSecondShoot)
        {
            Mathf.Clamp(secondPinCount[i], 0, 10 - firstPinCount[i]);
            secondPinCount[i] = int.Parse(InputField.text);
            if (int.Parse(InputField.text) > 10 - firstPinCount[i])
            {
                Debug.Log("남은 핀 개수를 초과합니다.");
                ShootCheck();
            } 
                
            if (firstPinCount[i] + secondPinCount[i] == 10)
                isSpare= true;

            Debug.Log(frame + secondPinCount[i]);

        }
        if (isThirdShoot)
        {
            thirdPinCount = int.Parse(InputField.text);
            Debug.Log(frame + thirdPinCount);
        }
        CalculateScore(i);
    }
    public void PrintScore(int i)
    {
        if (isStrike == true)
        {
            firstScoretxt[i].text = "X";
            secondScoretxt[i].text = "";
            sumScoretxt[i].text = $"{score[i]}";
            Debug.Log("Show" + frame + firstPinCount[i]);
        }
        if (isSpare)
        {
            firstScoretxt[i].text = $"{firstPinCount[i]}";
            secondScoretxt[i].text = "/";
            sumScoretxt[i].text = $"{score[i]}";
            Debug.Log("Show" + frame + firstPinCount[i]);
        }
        else
        {
            firstScoretxt[i].text = $"{firstPinCount[i]}";
            secondScoretxt[i].text = $"{secondPinCount[i]}";
            sumScoretxt[i].text = $"{score[i]}";
            Debug.Log("Show" + frame + firstPinCount[i]);
        }
        CalculateScore(i);
    }
    public void CalculateScore(int i)
    {
        while (frame < 10)
        { 
            if (frame == 9)
            {
                if (isfirstShoot == true && isStrike == true)
                    isThirdShoot = true;
                if (isSecondShoot == true && isSpare == true)
                    isThirdShoot = true;
            }
            if (isStrike == true)
            {
                /*if (isThirdShoot)
                {
                    
                }
                else 
                {   
                    score[i] = 10 + firstPinCount[i] + secondPinCount[i] + score[i - 1];
                }
                sumScoretxt[i].text = $"{score[i]}";*/
                continue;
            }
            if (isSpare)
            {
                /*if (isThirdShoot)
                {

                }
                else
                {
                    score[i] = 10 + firstPinCount[i] + score[i - 1];
                    firstScoretxt[i].text = $"{firstPinCount[i]}";
                    secondScoretxt[i].text = "/";
                }
                sumScoretxt[i].text = $"{score[i]}";*/
                continue;

            }
            else
            {
                if (isfirstShoot == true)
                {
                    isSecondShoot = true;
                    isfirstShoot= false;   
                    firstScoretxt[i].text = $"{firstPinCount}";
                }
                 


                if (isSecondShoot == true)
                {
                    isfirstShoot = true;
                    isSecondShoot= false;
                    secondScoretxt[i].text = $"{secondPinCount}";
                    score[i] = firstPinCount[i] + secondPinCount[i];
                    sumScoretxt[i].text = $"{score[i]}";

                }
                 
            }
            InputCheck();

        }
    }
}
