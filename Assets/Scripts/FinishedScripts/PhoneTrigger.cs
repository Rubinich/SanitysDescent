using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTrigger : MonoBehaviour
{
    public PhoneController phoneController;
    public GameObject toEnable;
    private bool hasTriggered = false;

    private void Start()
    {
        if (toEnable.TryGetComponent<Renderer>(out var renderer))
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = Instantiate(materials[i]);
            }
            renderer.materials = materials;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            phoneController.PlayRingAudio();
            hasTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            toEnable.SetActive(true);
        }
    }
}
