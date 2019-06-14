using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public AudioClip collectSFX;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Head>())
        {
            SFXManager.instance.Play(collectSFX);
            collision.gameObject.GetComponent<Head>().Grow();
            Destroy(this.gameObject);
        }
    }
}
