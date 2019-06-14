using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = Screen.height / 2;
    }
}
