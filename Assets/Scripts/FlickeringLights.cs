using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    public Light lightIn;
    public AudioSource lightSound;
    public float minTime;
    public float maxTime;
    public float timer;
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        LightFlickering();
    }
    public void LightFlickering()
    {
        if(timer > 0)
            timer -= Time.deltaTime;
        if(timer <= 0)
        {
            lightIn.enabled = !lightIn.enabled;
            timer = Random.Range(minTime, maxTime);
            lightSound.Play();
        }
    }
}
