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
        ringSource = GetComponent<AudioSource>();
        ringSource.clip = ringClip;
        callSource = GetComponent<AudioSource>();
        callSource.clip = callClip;
    }
    public void PlayMusic()
    {
        ringSource.Play();
    }
}
