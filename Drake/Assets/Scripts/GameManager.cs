using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int xDim;
    public int yDim;

    public GameObject gameOverUI;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }


    public void Step ()
    {
        FoodManager.instance.Rot();
        ScoreManager.instance.IncrementStep();

        List<Vector3> l = GameObject.FindGameObjectWithTag("Player").GetComponent<Head>().GetCells();
        Vector3 head = l[0];
        l.RemoveAt(0);
        if (l.Count != 0) l.RemoveAt(0);  // The head should never be able to touch the 2nd node

        if (l.Count != 0 && l.Contains(head))
        {
            GameOver();
        }
    }


    public void GameOver ()
    {
        Time.timeScale = 0;
        ScoreManager.instance.ArchiveScore();
        gameOverUI.SetActive(true);
    }


    public void ReloadGame ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Game");
    }

    public void QuitGame ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    
}
