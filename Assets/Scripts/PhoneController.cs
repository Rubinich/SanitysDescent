using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public AudioClip musicClip; // The audio clip to play
    public AudioSource phoneAudioSource; // The audio source component attached to the phone

    private void OnTriggerEnter(Collider other)
    {
            // Check if the phone audio source and music clip are assigned
            if (phoneAudioSource != null && musicClip != null)
            {
                // Play the music clip on the phone audio source
                phoneAudioSource.clip = musicClip;
                phoneAudioSource.Play();
            }
    }
}
