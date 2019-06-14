using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{


    public Node next = null;
    public Node GetNext () { return next; }
    public void SetNext (Node n) { next = n; }
    

    Vector3 lastPosition;
    public Vector3 GetLastPosition () { return lastPosition; }



    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void MoveTo (Vector3 nextCell)
    {
        lastPosition = transform.position;

        GetComponent<Mover>().SetDestination(nextCell);
        //transform.Translate(nextCell - transform.position);
        //transform.position = nextCell;

        if (next != null)
        {
            next.MoveTo(lastPosition);
        }
    }


    public Vector3 GetCell ()
    {
        float x = Mathf.Floor(transform.position.x) + 0.5f;
        float y = Mathf.Floor(transform.position.y) + 0.5f;
        float z = transform.position.z;

        return new Vector3(x, y, z);
    }
}
