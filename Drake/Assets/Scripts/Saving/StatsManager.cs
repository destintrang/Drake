using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{


    /// <summary>
    /// KEEPS TRACK OF THE PLAYER'S PROGRESS OVER ALL RUNS
    /// </summary>


    public int runs = 0;
    public int steps = 0;

    public int eggsHighscore = 0;
    public int eggsTotal = 0;
    public float eggsAverage = 0.0f;

    public int pointsHighscore = 0;
    public float pointsAverage = 0.0f;

    //Stunts
    public int jumpedOverTotal = 0;
    public int swamUnderTotal = 0;

    public int GetRuns () { return runs; }
    public int GetSteps () { return steps; }
    public int GetEggsHighscore () { return eggsHighscore; }
    public int GetEggsTotal () { return eggsTotal; }
    public float GetEggsAverage () { return eggsAverage; }
    public int GetPointsHighscore () { return pointsHighscore; }
    public float GetPointsAverage () { return pointsAverage; }
    public int GetJumped () { return jumpedOverTotal; }
    public int GetSwam() { return swamUnderTotal; }


    public static StatsManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            ImportPlayerData(SaveManager.LoadData());
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


    public void UpdateStats (int e, int p, int s, int jumped, int swam)
    {
        runs++;
        steps += s;

        eggsHighscore = Mathf.Max(e, eggsHighscore);
        eggsTotal += e;
        eggsAverage = (float)eggsTotal / (float)runs;

        pointsHighscore = Mathf.Max(p, pointsHighscore);
        float totalPoints = (pointsAverage * (runs - 1)) + p;
        pointsAverage = (float)totalPoints / (float)runs;

        jumpedOverTotal += jumped;
        swamUnderTotal += swam;
    }

    

    //Load stats saved on the computer
    public void ImportPlayerData(PlayerData data)
    {

        runs = data.runs;
        steps = data.steps;

        eggsHighscore = data.eggsHighscore;
        eggsTotal = data.eggsTotal;
        eggsAverage = data.eggsAverage;

        pointsHighscore = data.pointsHighscore;
        pointsAverage = data.pointsAverage;

        this.jumpedOverTotal = data.jumpedOverTotal;
        this.swamUnderTotal = data.swamUnderTotal;

    }
    //Create and return a PlayerData object initialized with this object
    public PlayerData ExportPlayerData()
    {
        return new PlayerData(this);
    }

}
