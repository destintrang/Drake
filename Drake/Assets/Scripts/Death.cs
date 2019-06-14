using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.GameOver();
    }
}
