using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    private DoorController raycastedObj1;
    private PhoneController raycastedObj2;
    [SerializeField] private KeyCode interact = KeyCode.Mouse0;
    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnceDoor;
    private bool doOncePhone;
    public bool canInteractWithPhone;
    private const string interactableTag = "InteractiveObject";

    private void Start()
    {
        canInteractWithPhone = true;
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
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
                        doOncePhone = false;
                    }
                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Phone"))
                {
                    if (!doOncePhone && canInteractWithPhone)
                    {
                        raycastedObj2 = hit.collider.gameObject.GetComponent<PhoneController>();
                        CrosshairChange(true);
                        isCrosshairActive = true;
                        doOncePhone = true;
                        doOnceDoor = false;
                        raycastedObj2.canSkipCall = true;
                    }
                }

                if (Input.GetKeyDown(interact))
                {
                    if (doOnceDoor && !raycastedObj1.IsDoorAnimationPlaying())
                    {
                        raycastedObj1.PlayAnimation();
                    }
                    else if (doOncePhone && !raycastedObj2.callSource.isPlaying)
                    {
                        raycastedObj2.PlayCallAudio();
                    }
                }
                if (doOncePhone && raycastedObj2.canSkipCall && Input.GetKeyDown(KeyCode.E))
                {
                    raycastedObj2.callSource.Stop();
                    raycastedObj2.isRinging = false;
                    raycastedObj2.hasPlayedCall = false;
                    raycastedObj2.canSkipCall = false;
                    canInteractWithPhone = false;
                    doOncePhone = false;
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
