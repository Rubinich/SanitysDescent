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
    private bool doOnce;
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
                if (!doOnce)
                {
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Door"))
                    {
                        raycastedObj1 = hit.collider.gameObject.GetComponent<DoorController>();
                        CrosshairChange(true);
                    }
                    else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Phone"))
                    {
                        raycastedObj2 = hit.collider.gameObject.GetComponent<PhoneController>();
                        CrosshairChange(true);
                    }
                        
                }
                isCrosshairActive = true;
                doOnce = true;
                if (Input.GetKeyDown(interact))
                {
                    raycastedObj1.PlayAnimation();
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }

    }
    void CrosshairChange(bool active)
    {
        if (active && !doOnce)
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