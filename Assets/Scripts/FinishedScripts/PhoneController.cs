using System;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public AudioSource ringSource;
    public bool isRinging;
    public AudioSource callSource;
    public bool hasPlayedCall;
    public bool hasPlayedRing;
    public float delayAction;
    public bool canSkipCall;

    public static event Action OnCallAudioStartEvent;
    public static event Action OnCallAudioStopEvent;

    public void PlayRingAudio()
    {
        if (ringSource != null && !callSource.isPlaying && !hasPlayedCall && !hasPlayedRing)
        {
            if (!isRinging)
            {
                ringSource.Play();
                isRinging = true;
                hasPlayedRing = true;
            }
        }
    }

    public void PlayCallAudio()
    {
        if (callSource != null && !callSource.isPlaying && !hasPlayedCall)
        {
            ringSource.Stop();
            isRinging = false;
            callSource.Play();
            hasPlayedCall = true;

            OnCallAudioStartEvent?.Invoke();

            StartCoroutine(DelayedAction());
        }
    }

    private System.Collections.IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(delayAction);

        EventTrigger eventTrigger = FindObjectOfType<EventTrigger>();
        if (eventTrigger != null)
        {
            eventTrigger.StartFlickeringLights();
        }

        OnCallAudioStopEvent?.Invoke();
    }
}
