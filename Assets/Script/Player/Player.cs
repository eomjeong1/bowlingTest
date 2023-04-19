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

    public Player(string playerName, int hdcpScore, int maxPossible, int strikeCount, int spareCount, int gutterCount)
    {
        this.playerName = playerName;
        this.hdcpScore = hdcpScore;
        this.maxPossible = maxPossible;
        this.strikeCount = strikeCount;
        this.spareCount = spareCount;
        this.gutterCount = gutterCount;
    }

    public void PlusScore(int plusScore)
    {
        hdcpScore += plusScore;
    }
    public void ScoreJudgement(int pinCount)
    {

    }


}
