using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAnimation : MonoBehaviour
{
    

    Animator a;
    Vector3 last;

    enum Dir { UP, DOWN, LEFT, RIGHT };
    Dir d;
    bool toSwitch = false;
    bool flying = false;


    // Start is called before the first frame update
    void Awake()
    {
        a = GetComponent<Animator>();
        last = transform.parent.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateDirection();
        UpdateAnimation();
    }


    void UpdateDirection ()
    {
        Vector3 difference = transform.parent.position - last;
        int z = (int) transform.parent.position.z;

        if (Mathf.Abs(difference.z) == 1) { toSwitch = true; }

        if (difference.y > 0)
        {
            d = Dir.UP;
        }
        else if (difference.y < 0)
        {
            d = Dir.DOWN;
        }
        else if (difference.x > 0)
        {
            d = Dir.RIGHT;
        }
        else if (difference.x < 0)
        {
            d = Dir.LEFT;
        }

        last = transform.position;
    }


    void UpdateAnimation ()
    {
        switch (d)
        {
            case Dir.UP:
                if (toSwitch)
                {
                    if (flying)
                    {
                        a.Play("Land Up");
                        GetComponent<SpriteRenderer>().sortingLayerName = "Object";
                    }
                    else
                    {
                        a.Play("Fly Up");
                        GetComponent<SpriteRenderer>().sortingLayerName = "Airborne";
                    }
                    flying = !flying;
                    toSwitch = false;
                }
                else
                {
                    if (!flying) a.SetInteger("Direction", 1);
                }
                break;
            case Dir.DOWN:
                if (toSwitch)
                {
                    if (flying)
                    {
                        a.Play("Land Down");
                        GetComponent<SpriteRenderer>().sortingLayerName = "Object";
                    }
                    else
                    {
                        a.Play("Fly Down");
                        GetComponent<SpriteRenderer>().sortingLayerName = "Airborne";
                    }
                    flying = !flying;
                    toSwitch = false;
                }
                else
                {
                    if (!flying) a.SetInteger("Direction", 2);
                }
                break;
            case Dir.LEFT:
                if (toSwitch)
                {
                    if (flying)
                    {
                        a.Play("Land Left");
                        GetComponent<SpriteRenderer>().sortingLayerName = "Object";
                    }
                    else
                    {
                        a.Play("Fly Left");
                        GetComponent<SpriteRenderer>().sortingLayerName = "Airborne";
                    }
                    flying = !flying;
                    toSwitch = false;
                }
                else
                {
                    if (!flying) a.SetInteger("Direction", 3);
                }
                break;
            case Dir.RIGHT:
                if (toSwitch)
                {
                    if (flying)
                    {
                        a.Play("Land Right");
                        GetComponent<SpriteRenderer>().sortingLayerName = "Object";
                    }
                    else
                    {
                        a.Play("Fly Right");
                        GetComponent<SpriteRenderer>().sortingLayerName = "Airborne";
                    }
                    flying = !flying;
                    toSwitch = false;
                }
                else
                {
                    if (!flying) a.SetInteger ("Direction", 4);
                }
                break;
        }
    }
    
}
