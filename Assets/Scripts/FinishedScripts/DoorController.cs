using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator anim;
    public AudioClip doorOpenClip;
    public AudioClip doorCloseClip;
    private AudioSource doorOpenSound;
    private AudioSource doorCloseSound;
    private bool doorOpen = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        doorOpenSound = gameObject.AddComponent<AudioSource>();
        doorOpenSound.clip = doorOpenClip;
        doorCloseSound = gameObject.AddComponent<AudioSource>();
        doorCloseSound.clip = doorCloseClip;
    }
    public void PlayAnimation()
    {
        if (!doorOpen) 
        {
            anim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
            if(!doorOpenSound.isPlaying)
            {
                DoorOpenSound();
            }
            
            
        }
        else
        {
            anim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
            if (!doorCloseSound.isPlaying)
            {
                DoorCloseSound();
            }
            
  
        }
    }
    public void DoorOpenSound()
    {
        doorOpenSound.Play();
    }
    public void DoorCloseSound()
    {
        doorCloseSound.Play();
    }
}
