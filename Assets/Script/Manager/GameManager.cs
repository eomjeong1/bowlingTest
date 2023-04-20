using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region SingletoneUI
    public static GameManager instance = null;
    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion

    public Player player = new Player("", 0, 0, 0, 0, 0);

    /*public bool isStrike;
    public bool isDouble;
    public bool isTriple;
    public bool isSpare;
    public bool isFirstShoot;
    public bool isSecondShoot;
    public bool isThirdShoot;
    public bool isLastFrame;
    public int FrameNum;
    // public int[] FrameNum = new int[9];
    public int[] firstpin = new int[9];
    public int[] lastpin = new int[9];
    public int FirstpinCount;
    public int SecondpinCount;
    public int ThirdpinCount;
    public int frame;

    public Text[] FrameNumber;
    public Text[] firstScore;
    public Text[] secondScore;
    public Text[] SumScore;
    //public bool isRound
*/
    public void Start()
    {

    }
    /*    public void FrameCheck()
        {
            for (int i = 0; i < FrameNum.Length; i++)
            {
                FrameNumber.text = $"{FrameNum[i]}";
                firstpin[i] = GameManager.GetInstance().firstpinCount;
                lastpin[i] = GameManager.GetInstance().lastpinCount;

                ScoreJudgement(firstpinCount, lastpinCount);
                FrameCount();
            }
        }*/
    /*public void NextFrame(int i)
    {
        FrameNum++;
        FrameNumber[i].text = $"{FrameNum++}";
        if (FrameNum == 10)
            isLastFrame = true;
        FirstScore(i);
    }

    IEnumerator FrameCount()
    {
        frame = 1;
        frame++;
        if (frame < 10)
        {
            return FrameCount();
        }
        return null;
    }
    public void FirstScore(int i)
    {
        for (int j = 0; j < firstpin.Length; j++)
        {
            if (FirstpinCount == 10)
            {
                firstScore[i].text = "X";
                secondScore[i].text = "";
                ScoreJudgement();
                NextFrame(i);
            }
            else if (FirstpinCount == 0)
            {
                firstScore[i].text = "-";
                SecondScore(i);
            }
            else
            {
                firstScore[i].text = FirstpinCount.ToString();
                SecondScore(i);
            }
        }
    }

    public void SecondScore(int i)
    {
        for (int j = 0; j < firstpin.Length; j++)
        {
            if (isSecondShoot == true)
            {
                j = i;
                if (SecondpinCount + FirstpinCount == 10)
                {
                    secondScore[i].text = "/";
                }
                else
                {
                    secondScore[i].text = GameManager.GetInstance().SecondpinCount.ToString();
                }
                ScoreJudgement();
                NextFrame(i);
            }
        }
    }

    public void ScoreJudgement()
    {
        if (!isLastFrame)
        {
            if (isFirstShoot)
            {
                if (isStrike)
                {
                    player.PlusScore(FirstpinCount * 2);
                    if (FirstpinCount == 10)
                    {
                        isStrike = true;
                        isSecondShoot = false;
                        isFirstShoot = true;
                        SecondpinCount = 0;
                    }

                    else
                    {
                        isSecondShoot = true;
                    }
                }
                else if (isDouble)
                {
                    player.PlusScore(FirstpinCount * 2);
                }
                else if (isSpare)
                {
                    isSpare = false;
                    player.PlusScore(FirstpinCount * 2);
                    if (FirstpinCount == 10)
                    {
                        isStrike = true;
                        isSecondShoot = false;
                        isFirstShoot = true;
                    }

                    else
                        isSecondShoot = true;
                }
                else
                {
                    player.PlusScore(FirstpinCount);
                }
            }
            if (isSecondShoot)
            {
                if (isStrike)
                {
                    player.PlusScore(SecondpinCount * 2);
                    if (FirstpinCount + SecondpinCount == 10)
                    {
                        isSpare = true;
                        isSecondShoot = false;
                        isFirstShoot = true;
                    }

                    else
                    {
                        isSecondShoot = false;
                        isFirstShoot = true;
                    }
                }
                else
                {
                    player.PlusScore(SecondpinCount);
                    isSecondShoot = false;
                    isFirstShoot = false;
                }
            }
        }
        else if (isLastFrame)
        { 
        
        }
    }*/

    
}