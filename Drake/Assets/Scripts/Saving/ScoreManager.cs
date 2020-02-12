using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    /// <summary>
    /// KEEPS TRACK OF THE PLAYER'S PROGRESS FOR THE CURRENT LEVEL ONLY
    /// </summary>


    int steps = 0;
    public void IncrementStep () { steps++; }

    int eggScore = 0;
    public Text eggs;

    int pointScore = 0;
    public Text points;

    float average = 0;
    public Text averagePoints;

    int eggsHighscore = 0;
    public Text eggsHighscoreText;
    int pointsHighscore = 0;
    public Text pointsHighscoreText;

    //Stunts
    int jumpedOver = 0;
    public void IncrementJumped () { jumpedOver++; }
    int swamUnder = 0;
    public void IncrementSwam () { swamUnder++; }


    //For animating number lerp
    float numberUpdateTime = 0.5f;


    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        eggsHighscore = StatsManager.instance.GetEggsHighscore();
        eggsHighscoreText.text = StatsManager.instance.GetEggsHighscore().ToString();
        pointsHighscore = StatsManager.instance.GetPointsHighscore();
        pointsHighscoreText.text = StatsManager.instance.GetPointsHighscore().ToString();
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

        //Check if we need to update the highscore
        if (eggScore > eggsHighscore)
        {
            eggsHighscore = eggScore;
            eggsHighscoreText.text = eggsHighscore.ToString();
        }

    }
    void IncrementPointScore(int p)
    {

        StartCoroutine(LerpNumber(points, pointScore, pointScore + p));
        pointScore += p;

        //Check if we need to update the highscore
        if (pointScore > pointsHighscore)
        {
            StartCoroutine(LerpNumber(pointsHighscoreText, pointsHighscore, pointScore));
            pointsHighscore = pointScore;
        }

    }
    void IncrementAverage ()
    {
        average = (float)pointScore / (float)eggScore;
        average = (Mathf.Round(average * 100)) / 100.0f;
        averagePoints.text = average.ToString();
    }


    IEnumerator LerpNumber (Text number, int original, int target)
    {

        float timer = 0;

        while (timer < numberUpdateTime)
        {
            timer += Time.deltaTime;
            number.text = ((int) Mathf.Lerp((float)original, (float)target, timer / numberUpdateTime)).ToString();
            yield return null;
        }

        number.text = target.ToString();

    }


    public void ArchiveScore ()
    {
        if (StatsManager.instance != null)
        {
            StatsManager.instance.UpdateStats(eggScore, pointScore, steps, jumpedOver, swamUnder);
        }
    }

}
