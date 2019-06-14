using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    int steps = 0;
    public void IncrementStep () { steps++; }

    int eggScore = 0;
    public Text eggs;

    int pointScore = 0;
    public Text points;

    float average = 0;
    public Text averagePoints;

    public Text eggsHighscore;
    public Text pointsHighscore;


    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        eggsHighscore.text = StatsManager.instance.GetEggsHighscore().ToString();
        pointsHighscore.text = StatsManager.instance.GetPointsHighscore().ToString();
    }


    public void IncrementScore (int p)
    {
        IncrementEggScore();
        IncrementPointScore(p);
        IncrementAverage();
    }
    void IncrementEggScore()
    {
        eggScore++;
        eggs.text = eggScore.ToString();
    }
    void IncrementPointScore(int p)
    {
        pointScore += p;
        points.text = pointScore.ToString();
    }
    void IncrementAverage ()
    {
        average = (float)pointScore / (float)eggScore;
        average = (Mathf.Round(average * 100)) / 100.0f;
        averagePoints.text = average.ToString();
    }


    public void ArchiveScore ()
    {
        if (StatsManager.instance != null)
        {
            StatsManager.instance.UpdateStats(eggScore, pointScore, steps);
        }
    }

}
