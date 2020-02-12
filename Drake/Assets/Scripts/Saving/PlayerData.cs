using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{


    public int runs;
    public int steps;
    
    public int eggsHighscore;
    public int eggsTotal;
    public float eggsAverage;
    
    public int pointsHighscore;
    public float pointsAverage;

    public int jumpedOverTotal;
    public int swamUnderTotal;


    public PlayerData()
    {
        runs = 0;
        steps = 0;

        eggsHighscore = 0;
        eggsTotal = 0;
        eggsAverage = 0.0f;

        pointsHighscore = 0;
        pointsAverage = 0.0f;

        jumpedOverTotal = 0;
        swamUnderTotal = 0;
    }
    public PlayerData (StatsManager s)
    {
        runs = s.GetRuns();
        steps = s.GetSteps();

        eggsHighscore = s.GetEggsHighscore();
        eggsTotal = s.GetEggsTotal();
        eggsAverage = s.GetEggsAverage();

        pointsHighscore = s.GetPointsHighscore();
        pointsAverage = s.GetPointsAverage();

        jumpedOverTotal = s.GetJumped();
        swamUnderTotal = s.GetSwam();
    }


    //Singleton
    public static PlayerData instance;
    private void Awake()
    {
        if (instance == null)
        {
            //CopyData(SaveManager.LoadData());
            instance = this;
        }
    }


    //public void InputResult (ScoreManager s)
    //{

    //    highScore = Mathf.Max(highScore, s.GetScore());
    //    highestWavesCleared = s.GetClearedWaves();
    //    runs++;

    //}


    //private void CopyData (PlayerData p)
    //{
    //    highScore = p.highScore;
    //    runs = p.runs;
    //}

}
