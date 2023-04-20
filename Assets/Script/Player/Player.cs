using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{ 
    public string playerName { get; private set; }
    public int hdcpScore { get; private set; }
    public int maxPossible { get; private set; }
    public int strikeCount { get; private set; }
    public int spareCount { get; private set; }
    public int gutterCount { get; private set; }

    public int shootCount { get; private set; }

    public Player(string playerName, int hdcpScore, int maxPossible, int strikeCount, int spareCount, int gutterCount, int shootCount)
    {
        this.playerName = playerName;
        this.hdcpScore = hdcpScore;
        this.maxPossible = maxPossible;
        this.strikeCount = strikeCount;
        this.spareCount = spareCount;
        this.gutterCount = gutterCount;
        this.shootCount = shootCount;
    }

    public void PlusScore(int plusScore)
    {
        hdcpScore += plusScore;
    }
    public void JudgeShootCount(ScoreBoard scoreBoard, int i)
    {
        switch (shootCount)
        {
            case 0:
                if (scoreBoard.firstPinCount[i] == 10)
                {
                    strikeCount++;
                    shootCount = 0;
                    scoreBoard.frame++;
                    Debug.Log("shootCount :" + shootCount);
                }
                else
                {
                    shootCount = 1;
                    Debug.Log("shootCount :" + shootCount);
                }
                break;
            case 1:
                if (scoreBoard.firstPinCount[i] + scoreBoard.secondPinCount[i] == 10)
                {
                    spareCount++;
                    shootCount = 0;
                    scoreBoard.frame++;
                    Debug.Log("shootCount :" + shootCount);
            
                }
                else
                {
                    shootCount = 0;
                    scoreBoard.frame++;
                    Debug.Log("shootCount :" + shootCount);
                    
                }
                break;
                case 2:
                if (scoreBoard.frame == 9 && scoreBoard.firstPinCount[i] == 10)
                {
                    shootCount = 1;
                    Debug.Log("shootCount :" + shootCount);
                }
                else
                {
                    shootCount = 2;
                    Debug.Log("shootCount :" + shootCount);
                }
                break;
        }
    }


}
