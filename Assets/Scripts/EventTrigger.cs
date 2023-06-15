using System.Collections;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public float durationDB2;
    public FlickeringLights[] flickeringLights;

    private bool hasTriggered = false;

    public void StartFlickeringLights()
    {
        StartCoroutine(FlickerLightsCoroutine());
        hasTriggered = true;
    }

    private IEnumerator FlickerLightsCoroutine()
    {
        foreach (FlickeringLights light in flickeringLights)
        {
            light.StartFlickering(durationDB2);
        }
        yield return null;
    }
}
