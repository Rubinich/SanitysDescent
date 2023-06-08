using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Transform PlayerCamera;
    public float distance = 5;
    public Image crosshair = null;
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
                CrosshairChange(true);
            }
            else
            {
                CrosshairChange(false);
            }
        }
    }
    void CrosshairChange(bool change)
    {
        if (change)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }
}
