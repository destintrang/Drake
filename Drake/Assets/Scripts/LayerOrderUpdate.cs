using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrderUpdate : MonoBehaviour
{

    private SpriteRenderer s;

    public int priority = 0;

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float sign = Mathf.Sign(transform.position.y);
        s.sortingOrder = (int)(-sign * Mathf.CeilToInt(Mathf.Abs(transform.position.y))) * 10 + priority;
    }
}
