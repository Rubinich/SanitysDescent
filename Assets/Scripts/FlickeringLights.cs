using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlickeringLights : MonoBehaviour
{
    public Light lightIn;
    public AudioSource lightSound;
    public Renderer lightModelRenderer;
    public Material lightOnMaterial;
    public Material lightOffMaterial;
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
        if (timer > 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (lightIn.enabled)
            {
                lightIn.enabled = false;
                lightModelRenderer.material = lightOffMaterial;
                lightSound.Stop();
            }
            else
            {
                lightIn.enabled = true;
                lightModelRenderer.material = lightOnMaterial;
                lightSound.time = Random.Range(0f, lightSound.clip.length);
                lightSound.Play();
            }

            timer = Random.Range(minTime, maxTime);
        }
    }
}