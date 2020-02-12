using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    public Text runsText;
    public Text stepsText;
    public Text eggsHighscoreText;
    public Text eggsTotalText;
    public Text eggsAverageText;
    public Text pointsHighscoreText;
    public Text pointsAverageText;
    public Text jumpedOverText;
    public Text swamUnderText;


    Camera currentCamera;
    ButtonManager currentButtonManager;


    // Start is called before the first frame update
    void Start()
    {
        currentCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame ()
    {
        SceneManager.LoadScene("Main Game");
    }


    public void SwitchCamera (Camera c)
    {
        currentCamera.gameObject.SetActive(false);
        c.gameObject.SetActive(true);
        currentCamera = c;
    }
    public void SwithButtonManager (ButtonManager b)
    {
        //currentButtonManager.Activate();
        currentButtonManager = b;
        //currentButtonManager.Activate();
    }


    public void UpdateStats ()
    {
        StatsManager s = StatsManager.instance;

        runsText.text = s.GetRuns().ToString();
        stepsText.text = s.GetSteps().ToString();
        eggsHighscoreText.text = s.GetEggsHighscore().ToString();
        eggsTotalText.text = s.GetEggsTotal().ToString();
        eggsAverageText.text = ((Mathf.Round(s.GetEggsAverage() * 100)) / 100.0).ToString();
        pointsHighscoreText.text = s.GetPointsHighscore().ToString();
        pointsAverageText.text = ((Mathf.Round(s.GetPointsAverage() * 100)) / 100.0).ToString();
        jumpedOverText.text = s.GetJumped().ToString();
        swamUnderText.text = s.GetSwam().ToString();
    }
}
