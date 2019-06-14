using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{


    int runs = 0;
    int steps = 0;

    int eggsHighscore = 0;
    int eggsTotal = 0;
    float eggsAverage = 0.0f;

    int pointsHighscore = 0;
    float pointsAverage = 0.0f;
    
    public int GetRuns () { return runs; }
    public int GetSteps () { return steps; }
    public int GetEggsHighscore () { return eggsHighscore; }
    public int GetEggsTotal () { return eggsTotal; }
    public float GetEggsAverage () { return eggsAverage; }
    public int GetPointsHighscore () { return pointsHighscore; }
    public float GetPointsAverage () { return pointsAverage; }


    public static StatsManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateStats (int e, int p, int s)
    {
        runs++;
        steps += s;

        eggsHighscore = Mathf.Max(e, eggsHighscore);
        eggsTotal += e;
        eggsAverage = (float)eggsTotal / (float)runs;

        pointsHighscore = Mathf.Max(p, pointsHighscore);
        float totalPoints = (pointsAverage * (runs - 1)) + p;
        pointsAverage = (float)totalPoints / (float)runs;
    }
}
