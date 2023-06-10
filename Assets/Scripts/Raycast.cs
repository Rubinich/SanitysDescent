using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] private int rayLenght = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    private DoorController raycastedObj1;
    private PhoneController raycastedObj2;
    [SerializeField] private KeyCode interact = KeyCode.Mouse0;
    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnceDoor;
    private bool doOncePhone;
    private const string interactableTag = "InteractiveObject";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLenght, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Door"))
                {
                    if (!doOnceDoor)
                    {
                        raycastedObj1 = hit.collider.gameObject.GetComponent<DoorController>();
                        CrosshairChange(true);
                        isCrosshairActive = true;
                        doOnceDoor = true;
                        doOncePhone = false; // za reset doOncePhone
                    }
                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Phone"))
                {
                    if (!doOncePhone)
                    {
                        raycastedObj2 = hit.collider.gameObject.GetComponent<PhoneController>();
                        CrosshairChange(true);
                        isCrosshairActive = true;
                        doOncePhone = true;
                        doOnceDoor = false; // za reset doOnceDoor
                    }
                }

                if (Input.GetKeyDown(interact))
                {
                    // ili imamo interakciju s vratima ili s telefonom
                    if (doOnceDoor && !raycastedObj1.IsDoorAnimationPlaying())
                    {
                        //Debug.Log("doOnceDoor: " + doOnceDoor);
                        raycastedObj1.PlayAnimation();
                        //Debug.Log("doOnceDoor: " + doOnceDoor);
                    }
                    else if (doOncePhone)
                    {
                        raycastedObj2.PlayCallAudio();
                        //Debug.Log("doOncePhone: " + doOncePhone);
                    }
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnceDoor = false;
                    doOncePhone = false;
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnceDoor = false;
                doOncePhone = false;
            }
        }
    }

    void CrosshairChange(bool active)
    {
        if ((active && !doOnceDoor) || (active && !doOncePhone))
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}
