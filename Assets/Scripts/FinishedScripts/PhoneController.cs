using UnityEngine;

public class PhoneController : MonoBehaviour
{
    //za zvonjavu telefona
    public AudioClip ringClip;
    private AudioSource ringSource;
    //za poziv
    public AudioClip callClip;
    private AudioSource callSource;

    private void Start()
    {
        ringSource = gameObject.AddComponent<AudioSource>();
        ringSource.clip = ringClip;

        callSource = gameObject.AddComponent<AudioSource>();
        callSource.clip = callClip;
    }
    public void PlayRingAudio()
    {
        if (!callSource.isPlaying)
        {
            ringSource.Play();
        }
    }

    public void PlayCallAudio()
    {
        if(!callSource.isPlaying)
        {
            ringSource.Stop();
            callSource.Play();    
        }
        
    }
}
