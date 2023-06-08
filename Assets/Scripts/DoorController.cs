using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator anim;
    private bool doorOpen = false;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void PlayAnimation()
    {
        if (!doorOpen) 
        {
            anim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            anim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
        }
    }
}
