using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public FlickeringLights myLight;
    public float durationDB2;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player")) // Adjust the tag as per your player's tag
        {
            myLight.StartFlickering(durationDB2);
            hasTriggered = true;
        }
    }
}
