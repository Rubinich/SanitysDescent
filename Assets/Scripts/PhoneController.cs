using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
    }
    public void PlayMusic()
    {
        audioSource.Play();
    }
}
