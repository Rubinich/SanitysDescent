using UnityEngine;

public class PhoneController : MonoBehaviour
{
    // Ringing audio
    public AudioClip ringClip;
    private AudioSource ringSource;
    private bool isRinging;

    // Call audio
    public AudioClip callClip;
    private AudioSource callSource;

    private void Start()
    {
        ringSource = gameObject.AddComponent<AudioSource>();
        ringSource.clip = ringClip;
        ringSource.loop = true;

        callSource = gameObject.AddComponent<AudioSource>();
        callSource.clip = callClip;
    }

    public void PlayRingAudio()
    {
        if (!callSource.isPlaying)
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
        if (!callSource.isPlaying)
        {
            ringSource.Stop();
            isRinging = false;
            callSource.Play();
            
        }
    }
}
