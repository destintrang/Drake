using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousObject : MonoBehaviour
{


    // To keep track of which object is over/under
    bool under = false;


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.z == collision.transform.position.z)
        {
            //GameManager.instance.GameOver();
        }
        else if (transform.position.z == 1)
        {
            // Cast a shadow on the object below
            collision.GetComponent<Animator>().Play("Shade In");
            under = false;
            //collision.transform.GetChild(0).GetComponent<SpriteRenderer>().color = shade;
            //print(collision.transform.GetChild(0).GetComponent<SpriteRenderer>().color);
        }
        else if (collision.transform.position.z == 1)
        {
            // Cast a shadow on this object
            GetComponent<Animator>().Play("Shade In");
            under = true;
            //transform.GetChild(0).GetComponent<SpriteRenderer>().color = shade;
            //print(transform.GetChild(0).GetComponent<SpriteRenderer>().color);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (under)
        {
            GetComponent<Animator>().Play("Shade Out");
        }
        else
        {
            collision.GetComponent<Animator>().Play("Shade Out");
        }

        under = false;
    }


}
