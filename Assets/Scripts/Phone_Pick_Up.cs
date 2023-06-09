using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone_Pick_Up : MonoBehaviour
{
    private bool isClicked = false;
    private AudioSource audioSource;
    public AudioClip pickupSound;
    public AudioSource otherAudioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isClicked = true;
                    HandlePhonePickup();
                }
            }
        }
    }

    void HandlePhonePickup()
    {
        // Disable the other audio source
        otherAudioSource.enabled = false;

        audioSource.PlayOneShot(pickupSound);

        // Implement your phone pickup logic here
        // For example, you can disable the object or trigger some event
    }
}
