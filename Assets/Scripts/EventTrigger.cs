using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public float durationDB2;
    public FlickeringLights[] flickeringLights;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            foreach (FlickeringLights light in flickeringLights)
            {
                light.StartFlickering(durationDB2);
            }

            hasTriggered = true;
        }
    }
}
