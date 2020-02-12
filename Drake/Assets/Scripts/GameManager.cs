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

    public void hi()
    {
        Debug.Log("HI");
    }
    public void Step ()
    {

        //MenuSFXManager.instance.PlayButtonNavi();
        FoodManager.instance.Rot();
        ScoreManager.instance.IncrementStep();

        List<Vector3> l = GameObject.FindGameObjectWithTag("Player").GetComponent<Head>().GetCells();
        Vector3 head = l[0];
        l.RemoveAt(0);
        if (l.Count != 0) l.RemoveAt(0);  // The head should never be able to touch the 2nd node

        //Check if the head collides with a node
        if (l.Count != 0 && l.Contains(head))
        {
            GameOver();
        }
        //Check if the head jumps over a node
        else if (head.z == 1)
        {

            Vector3 jumpedOver = new Vector3(head.x, head.y, 0);
            if (l.Count != 0 && l.Contains(jumpedOver))
            {
                //A jump stunt has been made
                ScoreManager.instance.IncrementJumped();
            }

        }
        else if (head.z == 0)
        {

            Vector3 swamUnder = new Vector3(head.x, head.y, 1);
            if (l.Count != 0 && l.Contains(swamUnder))
            {
                //An under stunt has been made
                ScoreManager.instance.IncrementSwam();
            }

        }

    }


    public void GameOver ()
    {
        Time.timeScale = 0;
        ScoreManager.instance.ArchiveScore();
        SaveProgress();
        gameOverUI.SetActive(true);
        //gameOverUI.GetComponent<ButtonManager>().Activate();
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


    private void SaveProgress ()
    {
        SaveManager.SaveData();
    }
    
}
