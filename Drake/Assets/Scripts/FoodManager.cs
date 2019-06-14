using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{


    public Food egg;
    Food currentEgg = null;

    public AudioClip eggSFX;

    int buffer = 0;
    int currentPoints = 100;
    public const float pointScale = 0.9f;
    public const int minPoints = 10;
    public const int maxPoints = 100;


    public static FoodManager instance;
    private void Awake()
    {
        instance = this;
        SpawnFood();
    }

    private void Update()
    {
        if (currentEgg == null)
        {
            ScoreManager.instance.IncrementScore(currentPoints);
            SpawnFood();
        }
    }


    public void Rot ()
    {
        if (currentEgg != null)
        {
            if (buffer > 0)
            {
                buffer--;
            }
            else if (buffer == 0)
            {
                currentPoints = Mathf.CeilToInt((float)currentPoints * pointScale);
                currentPoints = Mathf.Clamp(currentPoints, minPoints, maxPoints);
            }
        }
    }


    void SpawnFood ()
    {
        currentEgg = Instantiate(egg, GetValidSpawn(), transform.rotation);
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        buffer = (int) (Mathf.Abs(currentEgg.transform.position.x - player.transform.position.x) + Mathf.Abs(currentEgg.transform.position.y - player.transform.position.y));
        currentPoints = 100;
    }

    Vector3 GetValidSpawn ()
    {
        List<Vector3> occupied = GameObject.FindGameObjectWithTag("Player").GetComponent<Head>().GetCells();

        float x = Random.Range(0, GameManager.instance.xDim) + 0.5f;
        float y = Random.Range(0, GameManager.instance.yDim) + 0.5f;

        Vector2 spawn = new Vector3(x, y, 0);

        while (ListContains(occupied, spawn))
        {
            x = Random.Range(0, GameManager.instance.xDim) + 0.5f;
            y = Random.Range(0, GameManager.instance.yDim) + 0.5f;
            spawn = new Vector3(x, y, 0);
        }

        return spawn;
    }


    bool ListContains (List<Vector3> l, Vector3 s)
    {
        foreach (Vector3 v in l)
        {
            if (s == new Vector3(v.x, v.y, 0)) { return true; }
        }

        return false;
    }

}
