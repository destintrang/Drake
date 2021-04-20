using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : Node
{

    Node tail = null;
    public GameObject body;

    public enum Direction { UP, DOWN, LEFT, RIGHT };
    Direction currentDirection = Direction.UP;
    Direction lastDirection;

    public bool toFly = false;

    public float interval = 1;
    float currentTimer = 0;
    public float cooldown = 60;

    const KeyCode UP    = KeyCode.W;
    const KeyCode DOWN  = KeyCode.S;
    const KeyCode LEFT  = KeyCode.A;
    const KeyCode RIGHT = KeyCode.D;
    const KeyCode FLY   = KeyCode.Space;


    private void Start()
    {
        tail = GetTail ();
    }

    private void FixedUpdate()
    {
        //UpdateDirection ();
        currentTimer += interval;

        if (currentTimer > cooldown)
        {
            GameManager.instance.Step();
            currentTimer = 0;
            MoveTo(GetNextCell());
        }
    }

    private void Update()
    {
        UpdateDirection();
    }


    Vector3 GetNextCell ()
    {
        int z = 0;

        if (toFly)
        {
            toFly = false;

            if (transform.position.z == 0)  //The head is not airborne
            {
                //This means we jump!
                z = 1;
                SFXManager.instance.PlayJump();
            } 
            else if (transform.position.z == 1)  //The head is airborne
            {
                z = -1;
            }
            else
            {
                print("???");
            }
        }
        else if (!toFly)
        {
            if (transform.position.z == 0)  //The head is not airborne
            {
                
            }
            else if (transform.position.z == 1)  //The head is airborne
            {
                z = -1;
            }
            else
            {
                print("???");
            }
        }


        switch (currentDirection)
        {
            case Direction.UP:
                lastDirection = Direction.UP;
                return (transform.position + new Vector3(0, 1, z));
            case Direction.DOWN:
                lastDirection = Direction.DOWN;
                return (transform.position + new Vector3(0, -1, z));
            case Direction.LEFT:
                lastDirection = Direction.LEFT;
                return (transform.position + new Vector3(-1, 0, z));
            case Direction.RIGHT:
                lastDirection = Direction.RIGHT;
                return (transform.position + new Vector3(1, 0, z));
        }

        return (transform.position + new Vector3(0, 1, 0));
    }


    public void Grow (int g = 1)
    {
        while (g > 0)
        {
            Vector3 spawn = new Vector3(tail.GetCell().x, tail.GetCell().y, 0);
            Node newNode = Instantiate(body, spawn, transform.rotation).GetComponent<Node>();
            tail.SetNext(newNode);
            tail = newNode;
            g--;
        }
    }


    Node GetTail()
    {
        if (tail) return tail;

        Node current = this;

        while (current)
        {
            if (current.GetNext() == null) return current;
            else { current = current.GetNext(); }
        }

        return current;
    }


    public List<Vector3> GetCells ()
    {
        List<Vector3> cells = new List<Vector3>();

        Node current = this;

        while (current)
        {
            cells.Add(current.GetCell());
            current = current.next;
        }

        return cells;
    }

    
    void UpdateDirection ()
    {
        //This is for jumping
        if (Input.GetButton("Submit"))
        {
            toFly = true;
        }

        if (Input.GetButtonDown("W") && lastDirection != Direction.DOWN) { currentDirection = Direction.UP; }
        else if (Input.GetButtonDown("S") && lastDirection != Direction.UP) { currentDirection = Direction.DOWN; }
        else if (Input.GetButtonDown("A") && lastDirection != Direction.RIGHT) { currentDirection = Direction.LEFT; }
        else if (Input.GetButtonDown("D") && lastDirection != Direction.LEFT) { currentDirection = Direction.RIGHT; }
    }

}
