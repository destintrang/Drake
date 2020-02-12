using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    AudioSource a;

    float originalPitch;

    [SerializeField] protected AudioClip quack;
    [SerializeField] protected AudioClip drakeJump;


    public static SFXManager instance;
    private void Awake()
    {
        instance = this;

        //Reference calls
        a = GetComponent<AudioSource>();
        originalPitch = a.pitch;
    }

    
    public void Play (AudioClip sfx)
    {
        Debug.Log("???");
        a.PlayOneShot(sfx);
    }

    public void PlayQuack()
    {
        ResetPitch();
        a.pitch *= Random.Range(0.8f, 1.2f);
        a.PlayOneShot(quack);
    }
    public void PlayJump()
    {
        ResetPitch();
        a.PlayOneShot(drakeJump);
    }


    //Reset the pitch to the base pitch before each SFX
    private void ResetPitch ()
    {
        a.pitch = originalPitch;
    }

}
