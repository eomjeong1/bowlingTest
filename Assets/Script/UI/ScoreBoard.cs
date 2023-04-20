using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreBoard : MonoBehaviour
{ 
    public int[] score = new int[10];           // ���� �迭
    public int frame = 0;                       // ���� ������
    
    bool isStrike;                              // ��Ʈ����ũ Ȯ��
    bool isSpare;                               // ����� Ȯ��
    int StrikeCheck;                            // ���� ��Ʈ����ũ Ȯ��(����, Ʈ����(��Ű))
    public int[] firstPinCount = new int[10];   // ù��° �������� �Ѿ��� ���� ���� �迭
    public int[] secondPinCount = new int[10];  // �ι�° �������� �Ѿ��� ���� ���� �迭
    int thirdPinCount;                          // 10��° ������ ���ʽ� �������� �Ѿ��� ���� ����
    int[] frameScore;                           // ���� ������ ����

    public Text[] firstScoretxt;                // ù��° ������ ���� ���� �ؽ�Ʈ �迭
    public Text[] secondScoretxt;               // �ι�° ������ ���� ���� �ؽ�Ʈ �迭
    public Text thirdScoretxt;                  // 10��° ������ ���ʽ� ������ ���� ���� �ؽ�Ʈ
    public Text[] sumScoretxt;                  // ������ �� �ջ� ���� �ؽ�Ʈ �迭

    public Button InputBtn;                     // �Ѿ�߸� �� ���� �Է� ��ư
    public InputField InputField;               // �Ѿ�߸� �� ���� �Է� ��

    public Player player = new Player("", 0, 0, 0, 0, 0, 0); // �÷��̾� ����

    public void Start()
    {
        OnclickBtn();
    }

    /// <summary>
    /// ��ư ��Ŭ�� ��� �߰�
    /// </summary>
    public void OnclickBtn()
    {
        InputBtn.onClick.AddListener(InputCheck);
    }

    /// <summary>
    /// �Էµ� �ؽ�Ʈ�� ������ ��ȯ
    /// </summary>
    public void InputCheck()
    {
        int i = frame;

        if (player.shootCount == 0) // ������ �� ù��° ���� �� ��
        {
            firstPinCount[i] = int.Parse(InputField.text);
            if (int.Parse(InputField.text) > 10) // �Էµ� ���� ������ 10�� �̻��̸� ���� 
            {
                Debug.Log("�� ������ �ʰ��մϴ�.");
                return;
            }
            if (firstPinCount[i] == 10)  // �Էµ� ���� ������ 10���� ��Ʈ����ũ
            {
                isStrike = true;
                switch (StrikeCheck)  // ���� ��Ʈ����ũ Ȯ��
                {
                    case (0):
                        if (StrikeCheck == 0) // ��Ʈ����ũ
                        {
                            if (firstPinCount[i] == 10)
                                StrikeCheck = 1;
                        }
                        break;
                    case (1):
                        if (StrikeCheck == 1) // ����
                        {
                            if (firstPinCount[i] == 10)
                                StrikeCheck = 2;
                        }
                        break;
                    case (2):
                        if (StrikeCheck == 2) // Ʈ����(��Ű)
                        {
                            if (firstPinCount[i] == 10)
                                StrikeCheck = 3;
                        }
                        break;

                }
            }
            else // �Էµ� ���� ������ 10�� �̸��̸�
            {
                isStrike = false;
                Debug.Log("isStrike = false");
            }
                Debug.Log("������" + frame + "1��° ��" + firstPinCount[i]);
        }

        else if (player.shootCount == 1) // ������ �� �ι�° ����
        {
            secondPinCount[i] = int.Parse(InputField.text);
            if (int.Parse(InputField.text) > 10 - firstPinCount[i]) 
                // �ι�° ���� ������ ù��° ���� ������ ������ �� 10�̻��̸� ����
            {
                Debug.Log("���� �� ������ �ʰ��մϴ�.");
            }

            if (firstPinCount[i] + secondPinCount[i] == 10) 
                // ù��° �ɰ� �ι�° ���� ���� 10�̸� �����
            {
                isSpare = true;
                Debug.Log("isSpare");
            }
            else
            {
                isSpare = false;
                Debug.Log("isSpare = false");
            }
 


            Debug.Log("������" + frame + "2��° ��" + secondPinCount[i]);
        }
        else // 3��° ����, 10�������� ���ʽ� ������ ��
        {
            thirdPinCount = int.Parse(InputField.text);
            Debug.Log(frame + thirdPinCount);
        }
        CalculateScore(i); // ���� ����Լ���
    }

    /// <summary>
    /// ������ ����ϴ� �Լ�
    /// </summary>
    /// <param name="i">���� ������</param>
    public void CalculateScore(int i)
    {

        Debug.Log("CalculateStart");

        if (player.shootCount == 0) // ù��° ������ ��
        {
            if (isStrike) // ��Ʈ����ũ ������ ��
            {
                if (StrikeCheck == 1) // ��Ʈ����ũ �϶�
                {
                    if (i > 0)
                        score[i] = score[i - 1] + firstPinCount[i] + secondPinCount[i] + firstPinCount[i+1] + secondPinCount[i+1]; // score[i-1] : �� �����ӱ��� ���� ����
                    else
                        score[i] = firstPinCount[i] + secondPinCount[i];

                    Debug.Log(score[i]);
                }
                if (StrikeCheck == 2) // ������ ��
                {
                    score[i] = score[i - 1] + firstPinCount[i] + secondPinCount[i] + firstPinCount[i + 1] + secondPinCount[i + 1] + firstPinCount[i + 2] + secondPinCount[i + 2];

                    Debug.Log(score[i]);
                    
                }
                else if (StrikeCheck == 3) // Ʈ������ ��
                {
                    score[i] = score[i - 1] + 30;

                    Debug.Log(score[i]);
                   
                }
            }
            else // ��Ʈ����ũ ���������� ������ ���ʽ� ������ ��
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