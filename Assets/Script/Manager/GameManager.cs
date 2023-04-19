using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Player player = new Player("",0,0,0,0,0);

    public bool lastStrike;
    public bool lastSpare;
    public bool firstShoot;
    public bool lastShoot;
    public int FrameNum;
    public int firstpinCount;
    public int lastpinCount;


    ScoreBoard scoreBoard;
    public void Start()
    {
        FrameNum = 1;
    }
    public void ScoreJudgement(int firstpinCount, int lastpinCount)
    {
        /*firstpinCount =
        lastpinCount = */
        if(firstShoot)
        {
            if (lastStrike)
            {
                player.PlusScore(firstpinCount * 2);
                if (firstpinCount == 10)
                {
                    lastStrike = true;
                    lastShoot = false;
                    firstShoot = true;
                    FrameNum++;
                    lastpinCount = 0;
                }

                else
                {
                    lastShoot = true;
                }
                    
                    


            }
            else if (lastSpare)
            {
                lastSpare = false;
                player.PlusScore(firstpinCount * 2);
                if (firstpinCount == 10)
                {
                    lastStrike = true;
                    lastShoot = false;
                    firstShoot = true;
                    FrameNum++;
                }
                
                else
                    lastShoot = true;
            }
            else
            { 
                player.PlusScore(firstpinCount);
            }
        }
        if (lastShoot)
        {
            if (lastStrike)
            {
                player.PlusScore(lastpinCount * 2);
                if (firstpinCount + lastpinCount == 10)
                {
                    lastSpare = true;
                    lastShoot = false;
                    firstShoot = true;
                    FrameNum++;
                }

                else
                {
                    lastShoot = false;
                    firstShoot = true;
                }
            }
            else
            {
                player.PlusScore(lastpinCount);
                lastShoot = false;
                firstShoot = false;
                FrameNum++;
            }
        }
    }
}
