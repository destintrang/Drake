using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{


    public Animator a;
    public DuckAnimation d;

    public float speed;

    public Vector3 destination;
    public void SetDestination (Vector3 d)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, d.z);
        destination = d;
    }


    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }


    void UpdatePosition ()
    {
        if (transform.position != destination)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }


}
