using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator anim;
    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;
    private bool doorOpen;
    private bool isDoorAnimationPlaying;
    private void Start()
    {
        anim = GetComponent<Animator>();

    }
    public void PlayAnimation()
    {
        if (!isDoorAnimationPlaying)
        {
            if (!doorOpen)
            {
                anim.Play("DoorOpen", 0, 0.0f);
                DoorOpenSound();
                doorOpen = true;
            }
            else
            {
                anim.Play("DoorClose", 0, 0.0f);
                DoorCloseSound();
                doorOpen = false;
            }
            isDoorAnimationPlaying = true;

            // za odgadanje postavljanja isDoorAnimationPlaying na false za vrijeme trajanja animacije
            float animationDuration = anim.GetCurrentAnimatorStateInfo(0).length;
            StartCoroutine(SetIsDoorAnimationPlayingFalse(animationDuration));
        }
    }
    public void DoorOpenSound()
    {
        if (doorOpenSound != null && !doorOpenSound.isPlaying)
        {
            doorOpenSound.Play();
        }
    }
    public void DoorCloseSound()
    {
        if (doorCloseSound != null && !doorCloseSound.isPlaying)
        {
            doorCloseSound.Play();
        }
    }
    private IEnumerator SetIsDoorAnimationPlayingFalse(float delay)
    {
        yield return new WaitForSeconds(delay);
        isDoorAnimationPlaying = false;
    }

    public bool IsDoorAnimationPlaying()
    {
        return isDoorAnimationPlaying;
    }
}