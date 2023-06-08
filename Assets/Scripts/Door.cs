using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform PlayerCamera;
    public float distance = 5;
    private bool opened = false;
    private Animator anim;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
        }
    }
     void Pressed()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "Door")
            {
                anim = hit.transform.GetComponentInParent<Animator>();
                opened = !opened;
                anim.SetBool("Opened", !opened);

            }
        }
    }
}
