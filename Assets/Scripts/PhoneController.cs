using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public AudioSource ringSource;
    private bool isRinging;
    public AudioSource callSource;

    public void PlayRingAudio()
    {
        if (ringSource != null && !callSource.isPlaying)
        {
            if (!isRinging)
            {
                ringSource.Play();
                isRinging = true;
            }
        }
    }

    public void PlayCallAudio()
    {
        if (callSource != null && !callSource.isPlaying)
        {
            ringSource.Stop();
            isRinging = false;
            callSource.Play();
            
        }
    }
}
