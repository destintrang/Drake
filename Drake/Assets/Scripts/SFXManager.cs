using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    AudioSource a;

    public static SFXManager instance;
    private void Awake()
    {
        instance = this;
        a = GetComponent<AudioSource>();
    }

    
    public void Play (AudioClip sfx)
    {
        a.PlayOneShot(sfx);
    }

}
