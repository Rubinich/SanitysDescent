using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerEvent : MonoBehaviour
{
    public PhoneController phoneController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            phoneController.PlayMusic();
        }
    }
}
